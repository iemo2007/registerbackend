using AutoMapper;
using MediatR;
using Registration.Application.Exceptions;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City city = await _unitOfWork.Cities.GetByIdAsync(request.Id);
            if(city == null) 
            {
                throw new NotFoundException(nameof(City), request.Id);
            }
            _unitOfWork.Cities.Delete(city);
            return Unit.Value;
        }
    }
}
