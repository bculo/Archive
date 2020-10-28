using MediatR;
using Microsoft.AspNetCore.Http;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Exceptions;
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
        private readonly IUserRepository _repo;
        private readonly ISignInOutService _service;
        private readonly ICurrentUser _user;
        private readonly IHttpContextAccessor _accessor;

        public LoginUserFormHandler(IUserRepository repo,
            ISignInOutService service,
            ICurrentUser user,
            IHttpContextAccessor accessor)
        {
            _repo = repo;
            _service = service;
            _user = user;
            _accessor = accessor;
        }

        public Response<Unit> Result { get; set; }

        public async Task<Response<Unit>> Handle(LoginUserFormCommand request, CancellationToken cancellationToken)
        {
            var valid = await _repo.ValidCredentials(request.Identifier, request.Password);

            if (!valid)
            {
                Result = Response.Error<Unit>("WrongCredentials", "Wrong user credentials");
                throw new AuthenticationException(Result);
            }

            var user = await _repo.GetArchiveUser(request.Identifier);

            await _service.SignInAsync(user);

            return Response.Success(Unit.Value);
        }
    }
}
