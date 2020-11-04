using MediatR;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using ModelArchive.Common;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ModelArchive.Application.Exceptions
{
    public class ArchiveAuthenticationException : Exception, IArchiveException
    {
        private readonly KeyValueErrorContainer _container;

        public ArchiveAuthenticationException(KeyValueErrorContainer container) : base("Authentication exception")
        {
            _container = container;
        }

        public ExceptionDetails GetDetails()
        {
            var errors = _container.Errors.ToDictionary(x => x.Key, y => y.Value);

            return new ExceptionDetails
            {
                Errors = errors,
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Authentication exception occurred",
            };
        }
    }
}
