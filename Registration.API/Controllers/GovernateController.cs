using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs;
using Registration.Application.Features.CityFeatures.Queries.GetAllCities;
using Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GovernateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDTO>>> Get()
        {
            List<GetGovernatesWithCitiesDTO> governates = await _mediator.Send(new GetGovernatesWithCitiesQuery());
            return Ok(governates);
        }
    }
}
