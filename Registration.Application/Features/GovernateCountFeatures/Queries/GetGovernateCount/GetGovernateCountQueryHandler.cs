using AutoMapper;
using MediatR;
using Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities;
using Registration.Application.Persistence;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateCountFeatures.Queries.GetGovernateCount
{
    public class GetGovernateCountQueryHandler : IRequestHandler<GetGovernateCountQuery, GovernateCount>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGovernateCountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GovernateCount> Handle(GetGovernateCountQuery request, CancellationToken cancellationToken)
        {
            GovernateCount governate = await _unitOfWork.GovernateCount.GetCountByGovernateId(request.id);
            return governate;
        }
    }
}
