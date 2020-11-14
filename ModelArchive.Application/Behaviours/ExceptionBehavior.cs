using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Behaviours
{
    /// <summary>
    /// Filter which act as exception logger. If exception occures in handler, exception behaviour saves exception in log table
    /// </summary>
    /// <exception cref="Exception">Error occured in handler. Filter propagate exception to next pipeline behaviour</exception>
    /// <typeparam name="TRequest">TRequest is command or query</typeparam>
    /// <typeparam name="TResponse">TResonse type dependes on TRequest... We dont care here about Response type</typeparam>
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public ExceptionBehavior()
        {

        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
