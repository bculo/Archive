using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm;
using ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm;
using System.Threading.Tasks;

namespace ModelArchive.WebApi.Controllers
{

    public class AuthenticationController : MediatRBaseController
    {
        [HttpPost("formreg")]
        public async Task<IActionResult> RegisterUserViaForm(RegisterUserFormCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserViaForm(LoginUserFormCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
