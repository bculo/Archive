using MediatR;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutCommand, Response<Unit>>
    {
        private readonly IAuthService _service;

        public LogoutHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task<Response<Unit>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _service.SignOutAsync();

            return Response.Success<Unit>(Unit.Value);
        }
    }
}
