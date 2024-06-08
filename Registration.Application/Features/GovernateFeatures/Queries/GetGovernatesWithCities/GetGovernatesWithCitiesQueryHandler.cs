using AutoMapper;
using MediatR;
using Registration.Application.DTOs;
using Registration.Application.Exceptions;
using Registration.Application.Features.CityFeatures.Queries.GetCityById;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities
{
    public class GetGovernatesWithCitiesQueryHandler : IRequestHandler<GetGovernatesWithCitiesQuery, List<GetGovernatesWithCitiesDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGovernatesWithCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetGovernatesWithCitiesDTO>> Handle(GetGovernatesWithCitiesQuery request, CancellationToken cancellationToken)
        {
            List<Governate> governates = await _unitOfWork.Governates.AllWithCities();
            List<GetGovernatesWithCitiesDTO> governateDTOs = _mapper.Map<List<GetGovernatesWithCitiesDTO>>(governates);
            return governateDTOs;
        }
    }
}
