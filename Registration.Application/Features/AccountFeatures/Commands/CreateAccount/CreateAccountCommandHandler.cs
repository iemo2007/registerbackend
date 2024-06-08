using AutoMapper;
using MediatR;
using Registration.Application.DTOs.Responses;
using Registration.Application.Persistence;
using Registration.Application.RabbitMQService;
using Registration.Application.RabbitMQService.Producers.GovernateCountNotification;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.AccountFeatures.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGovernateCountNotificationService _governateCountNotification;

        public CreateAccountCommandHandler(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IGovernateCountNotificationService governateCountNotification)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _governateCountNotification = governateCountNotification;
        }
        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccountCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.requestDTO, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Select(e => e.ErrorMessage).FirstOrDefault();
                throw new Exception(errorMessage);
            }
            Account account = _mapper.Map<Account>(request.requestDTO);

            await _unitOfWork.Accounts.CreateAsync(account);
            await _unitOfWork.Complete();

            foreach (var governateId in request.requestDTO.Addresses.Select(a => a.GovernateId))
            {
                await _governateCountNotification.SentNotification(governateId);
            }

            return Guid.NewGuid();
        }
    }
}
