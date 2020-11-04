using MediatR;
using Microsoft.Extensions.Localization;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Exceptions;
using ModelArchive.Application.Models;
using ModelArchive.Application.Resources;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.SetUserLanguage
{
    public class SetUserLanguageHandler : IRequestHandler<SetUserLanguageCommand, Response<Unit>>
    {
        private readonly IUserRepository _repo;
        private readonly ICurrentUser _user;
        private readonly IStringLocalizer<HandlerResponseMessages> _localizer;
        private readonly IAuthService _authService;

        public SetUserLanguageHandler(IUserRepository repo,
            ICurrentUser user,
            IStringLocalizer<HandlerResponseMessages> localizer,
            IAuthService authService)
        {
            _repo = repo;
            _user = user;
            _localizer = localizer;
            _authService = authService;
        }

        public async Task<Response<Unit>> Handle(SetUserLanguageCommand request, CancellationToken cancellationToken)
        {
            var success = await _repo.SetUserLanguage(_user.UserName, request.Language);

            if (success)
            {
                await _authService.CreateCultureCookie(request.Language);

                return Response.Success<Unit>(Unit.Value);
            }

            throw new ArchiveException(_localizer["Error occured on language change"].Value);
        }
    }
}
