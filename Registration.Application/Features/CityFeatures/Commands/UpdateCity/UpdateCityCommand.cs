using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.UpdateCity
{
    public record UpdateCityCommand(CityDTO cityDTO): IRequest<Unit>;
}
