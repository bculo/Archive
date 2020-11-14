using FluentValidation.Results;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using ModelArchive.Common;
using System;
using System.Collections.Generic;
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

        public IDictionary<string, string[]> Errors { get; private set; }

        public ArchiveValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = new Dictionary<string, string[]>();

            var test = failures.GroupBy(e => e.PropertyName);

            foreach (var failureGroup in test)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.Select(i => i.ErrorMessage).ToArray();
                Errors.Add(propertyName, propertyFailures);
            }
        }

        public ExceptionDetails GetDetails()
        {
            if (_container != null)
            {
                var errors = _container.Errors.ToDictionary(x => x.Key, y => y.Value.ToArray());

                return new ExceptionDetails
                {
                    Title = "Validation exception",
                    Status = (int)HttpStatusCode.BadRequest,
                    Errors = errors,
                };
            }

            return new ExceptionDetails
            {
                Title = "Validation exception",
                Status = (int)HttpStatusCode.BadRequest,
                Errors = Errors,
            };
        }
    }
}
