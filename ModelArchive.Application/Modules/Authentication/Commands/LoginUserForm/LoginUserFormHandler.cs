using MediatR;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    class LoginUserFormHandler : IRequestHandler<LoginUserFormCommand, Response<Unit>>
    {
        private readonly IAuthService _service;

        public LoginUserFormHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task<Response<Unit>> Handle(LoginUserFormCommand request, CancellationToken cancellationToken)
        {
            var validCredentials = await _service.ValidCredentials(request.Identifier, request.Password);

            await _service.SignIn(request.Identifier);

            return Response.Success(Unit.Value);
        }
    }
}
