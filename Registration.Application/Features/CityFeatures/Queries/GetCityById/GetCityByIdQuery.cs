using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Queries.GetCityById
{
    public record GetCityByIdQuery(Guid Id): IRequest<CityDTO>;
}
