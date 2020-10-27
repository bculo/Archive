using MediatR;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm
{
    class RegisterUserFormHandler : IRequestHandler<RegisterUserFormCommand, Response<Unit>>
    {
        private readonly IAuthService _service;

        public RegisterUserFormHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task<Response<Unit>> Handle(RegisterUserFormCommand request, CancellationToken cancellationToken)
        {
            await _service.Register(request.UserName, request.Email, request.Password);

            return Response.Success(Unit.Value);
        }
    }
}
