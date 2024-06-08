using MediatR;
using Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateCountFeatures.Queries.GetGovernateCount
{
    public record GetGovernateCountQuery(Guid id) : IRequest<GovernateCount>;
}
