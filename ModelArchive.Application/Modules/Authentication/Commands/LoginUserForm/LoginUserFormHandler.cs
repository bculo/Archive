
using MediatR;
using Microsoft.Extensions.Localization;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Exceptions;
using ModelArchive.Application.Models;
using ModelArchive.Application.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    class LoginUserFormHandler : IRequestHandler<LoginUserFormCommand, Response<Unit>>
    {
        private readonly IUserRepository _repo;
        private readonly IAuthService _service;
        private readonly IStringLocalizer<HandlerResponseMessages> _localizer;

        public LoginUserFormHandler(IUserRepository repo,
            IAuthService service,
            IStringLocalizer<HandlerResponseMessages> localizer)
        {
            _repo = repo;
            _service = service;
            _localizer = localizer;
        }

        public Response<Unit> Result { get; set; }

        public async Task<Response<Unit>> Handle(LoginUserFormCommand request, CancellationToken cancellationToken)
        {
            var valid = await _repo.ValidCredentials(request.Identifier, request.Password);

            if (!valid)
            {
                Result = Response.Error<Unit>("WrongCredentials", _localizer["Wrong user credentials"].Value);
                throw new ArchiveAuthenticationException(Result);
            }

            var user = await _repo.GetArchiveUser(request.Identifier);

            await _service.SignInAsync(user);

            return Response.Success(Unit.Value);
        }
    }
}
