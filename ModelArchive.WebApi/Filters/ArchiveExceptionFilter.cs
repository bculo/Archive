using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ModelArchive.WebApi.Filters
{
    public class ArchiveExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostEnvironment _environment;

        public ArchiveExceptionFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is IArchiveException)
                HandleArchiveException(context);

            base.OnException(context);
        }

        private void HandleArchiveException(ExceptionContext context)
        {
            IArchiveException exception = context.Exception as IArchiveException;

            ExceptionDetails details = exception.GetDetails();

            AddAdditionalInformation(context, details);

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void AddAdditionalInformation(ExceptionContext context, ExceptionDetails details)
        {
            details.TraceId = context.HttpContext.TraceIdentifier;

            if (_environment.IsDevelopment())
            {
                //details.Detail = context.Exception.ToString();
            }
        }
    }
}
