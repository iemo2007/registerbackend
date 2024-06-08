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

namespace Registration.Application.Features.CityFeatures.Queries.GetAllCities
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<CityDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CityDTO>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            List<City> cities = await _unitOfWork.Cities.GetAsync();
            
            // COnvert the models into DTOs
            List<CityDTO> CityDTOs = _mapper.Map<List<CityDTO>>(cities);

            // Return the list of DTOs
            return CityDTOs;
        }
    }
}
