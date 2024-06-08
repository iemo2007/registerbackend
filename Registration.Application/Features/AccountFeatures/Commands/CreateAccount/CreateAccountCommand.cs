using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.AccountFeatures.Commands.CreateAccount
{
    public record CreateAccountCommand(CreateAccountCommandDTO requestDTO) : IRequest<Guid>;
}
