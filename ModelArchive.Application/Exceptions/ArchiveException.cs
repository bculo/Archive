using ModelArchive.Application.Contracts;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ModelArchive.Application.Exceptions
{
    public class ArchiveException : Exception, IArchiveException
    {
        public ArchiveException() : base()
        {

        }

        public ArchiveException(string message) : base(message)
        {

        }

        public ExceptionDetails GetDetails()
        {
            return new ExceptionDetails
            {
                Errors = Message,
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Bad request"
            };
        }
    }
}
