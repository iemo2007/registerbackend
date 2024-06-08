using MediatR;
using Registration.Application.Features.AccountFeatures.Commands.CreateAccount;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateCountFeatures.Commands.IncreaseGovernateCount
{
    public record IncreaseGovernateCountCommand(Guid governateId) : IRequest<Unit>;
}
