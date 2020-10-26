using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ModelArchive.Application.Contracts.Authentication;
using ModelArchive.WebApi.Models.Authentication;

namespace ModelArchive.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _auth;

        public AuthenticationController(IAuthenticationService auth)
        {
            _auth = auth;
        }

        [HttpPost(Name = "formreg")]
        public async Task<IActionResult> RegisterUserViaForm(UserRegistrationFormModel form)
        {
            var result = await _auth.Register(form.UserName, form.Email, form.Password);
            return Ok(result);
        }
    }
}
