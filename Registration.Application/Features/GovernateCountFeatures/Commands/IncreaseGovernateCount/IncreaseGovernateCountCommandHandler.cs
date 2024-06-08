using MediatR;
using Registration.Application.DTOs;
using Registration.Application.Features.AccountFeatures.Commands.CreateAccount;
using Registration.Application.Features.GovernateCountFeatures.Queries.GetGovernateCount;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateCountFeatures.Commands.IncreaseGovernateCount
{
    public class IncreaseGovernateCountCommandHandler : IRequestHandler<IncreaseGovernateCountCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public IncreaseGovernateCountCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(IncreaseGovernateCountCommand request, CancellationToken cancellationToken)
        {
            GovernateCount governate = await _mediator.Send(new GetGovernateCountQuery(request.governateId));
            if(governate == null) 
            {
                GovernateCount GovernateCount = new GovernateCount
                {
                    GovernateId = request.governateId,
                    Count = 1
                };
                await _unitOfWork.GovernateCount.CreateAsync(GovernateCount);
            }
            else
            {
                governate.Count++;
                _unitOfWork.GovernateCount.Update(governate);
            }
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
