using FluentValidation;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.CityFeatures.Commands.CreateCity
{
    public class CreateCityCommandValidator: AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            
        }
    }
}
