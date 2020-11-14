using FluentValidation;
using MediatR;
using ModelArchive.Application.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Behaviours
{
    /// <summary>
    /// Filter for fluent validation. Request model validation filter
    /// If Error is found, ArchiveValidationException is thrown
    /// </summary>
    /// <exception cref="ArchiveValidationException">Error occures on request model validation</exception>
    /// <typeparam name="TRequest">TRequest is command or query</typeparam>
    /// <typeparam name="TResponse">TResonse type dependes on TRequest... We dont care here about Response type</typeparam>
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
                throw new ArchiveValidationException(failures);

            return await next();
        }
    }
}
