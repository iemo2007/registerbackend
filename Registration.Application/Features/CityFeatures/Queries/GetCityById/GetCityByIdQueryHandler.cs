using AutoMapper;
using MediatR;
using Registration.Application.DTOs;
using Registration.Application.Exceptions;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CityDTO> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            City city = await _unitOfWork.Cities.GetByIdAsync(request.Id);
            if (city == null)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }
            CityDTO cityDTO = _mapper.Map<CityDTO>(city);
            return cityDTO;
        }
    }
}
