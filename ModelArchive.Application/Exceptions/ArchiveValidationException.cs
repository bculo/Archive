using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using ModelArchive.Common;
using System;
using System.Linq;
using System.Net;

namespace ModelArchive.Application.Exceptions
{
    public class ArchiveValidationException : Exception, IArchiveException
    {
        private readonly PropertyErrorContainer _container;

        public ArchiveValidationException(PropertyErrorContainer container)
        {
            _container = container;
        }

        public ExceptionDetails GetDetails()
        {
            var errors = _container.Errors.ToDictionary(x => x.Key, y => y.Value.ToArray());

            return new ExceptionDetails
            {
                Title = "Validation exception",
                Status = (int)HttpStatusCode.BadRequest,
                Errors = errors,
            };
        }
    }
}
