using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm;
using ModelArchive.Application.Modules.Authentication.Commands.Logout;
using ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm;
using ModelArchive.Application.Modules.Authentication.Commands.SetUserLanguage;
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
            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpPost("language")]
        public async Task<IActionResult> SetUserLanguage(SetUserLanguageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserViaForm(LoginUserFormCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            return Ok(await Mediator.Send(new LogoutCommand { }));
        }
    }
}
