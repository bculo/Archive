using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Exceptions;
using ModelArchive.Application.Models;
using ModelArchive.Common;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm
{
    class RegisterUserFormHandler : IRequestHandler<RegisterUserFormCommand, Response<Unit>>
    {
        private readonly IUserRepository _repo;

        public RegisterUserFormHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<Unit>> Handle(RegisterUserFormCommand request, CancellationToken cancellationToken)
        {
            var storageResult = await _repo.AddUser(request.UserName, request.Email, request.Password);

            if(storageResult.Success)
                return Response.Success(Unit.Value);

            var mapping = MapStorageResultsToPropertyErrors(storageResult);

            if (mapping.ContainsError)
                throw new ArchiveValidationException(mapping);

            throw new ArchiveException();
        }

        private PropertyErrorContainer MapStorageResultsToPropertyErrors(QueryResult<UserQuery> storageResult)
        {
            var propertyErrors = new PropertyErrorContainer();

            var userNameErrors = GetErrorsForProperty("UserName", storageResult);
            propertyErrors.AddPropertyErrors("UserName", userNameErrors);

            var emailErrors = GetErrorsForProperty("Email", storageResult);
            propertyErrors.AddPropertyErrors("Email", emailErrors);

            var passwordErros = GetErrorsForProperty("Password", storageResult);
            propertyErrors.AddPropertyErrors("Password", passwordErros);

            return propertyErrors;
        }

        public IEnumerable<string> GetErrorsForProperty(string property, QueryResult<UserQuery> storageResult)
        {
            return storageResult.Errors
                    .Where(i => i.Key.Contains(property, StringComparison.CurrentCultureIgnoreCase))
                    .Select(i => i.Value);
        }
    }
}
