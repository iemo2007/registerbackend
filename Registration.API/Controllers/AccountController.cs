using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Features.AccountFeatures.Commands.CreateAccount;
using Registration.Application.Features.CityFeatures.Queries.GetAllCities;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccountCommandDTO accountDTO)
        {
            await _mediator.Send(new CreateAccountCommand(accountDTO));
            return Ok();
        }
    }
}
