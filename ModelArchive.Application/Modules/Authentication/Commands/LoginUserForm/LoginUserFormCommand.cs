using MediatR;
using ModelArchive.Application.Models;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    public class LoginUserFormCommand : IRequest<Response<Unit>>
    {
        public string Identifier { get; set; }
        public string Password { get; set; }
    }
}
