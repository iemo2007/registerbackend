using AutoMapper;
using MediatR;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            // Validate data

            City city = _mapper.Map<City>(request.CityDTO);
            await _unitOfWork.Cities.CreateAsync(city);
            return city.Id;
        }
    }
}
