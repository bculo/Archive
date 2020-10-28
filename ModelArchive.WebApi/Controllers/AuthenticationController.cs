using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.HttpSys;
using ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm;
using ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm;
using System.Threading.Tasks;

namespace ModelArchive.WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : MediatRBaseController
    {
        [HttpPost("formreg")]
        public async Task<IActionResult> RegisterUserViaForm(RegisterUserFormCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

    
        [HttpGet("test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok("OK");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserViaForm(LoginUserFormCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
