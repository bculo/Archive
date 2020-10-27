using MediatR;
using ModelArchive.Application.Models;

namespace ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm
{
    public class RegisterUserFormCommand : IRequest<Response<Unit>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }
    }
}
