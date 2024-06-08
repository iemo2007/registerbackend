using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.CreateCity
{
    public class CreateCityCommand: IRequest<Guid>
    {
        public CityDTO CityDTO { get; set; }
    }
}
