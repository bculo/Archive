using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly ISignInOutService _service;
        private readonly IHttpContextAccessor _accessor;

        public RegisterUserFormHandler(ISignInOutService service, IHttpContextAccessor accessor)
        {
            _service = service;
            _accessor = accessor;
        }

        public async Task<Response<Unit>> Handle(RegisterUserFormCommand request, CancellationToken cancellationToken)
        {

            return Response.Success(Unit.Value);
        }
    }
}
