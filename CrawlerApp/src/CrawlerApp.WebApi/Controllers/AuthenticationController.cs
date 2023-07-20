using CrawlerApp.Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerApp.WebApi.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(AuthRegisterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
