using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.DTOs.Responses;

namespace Registration.API.Controllers
{
    [Route("api/[controller]/{code}")]

    [ApiExplorerSettings(IgnoreApi = true)]

    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return NotFound(new APIResponse(code));
        }
    }
}
