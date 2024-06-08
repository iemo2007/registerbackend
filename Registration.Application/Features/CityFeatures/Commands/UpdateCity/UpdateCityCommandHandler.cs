using AutoMapper;
using MediatR;
using Registration.Application.DTOs;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            // Validate Model

            City city = _mapper.Map<City>(request.cityDTO);
            _unitOfWork.Cities.Update(city);
            return Unit.Value;
        }
    }
}
