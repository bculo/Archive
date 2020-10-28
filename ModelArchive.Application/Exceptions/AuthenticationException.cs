using MediatR;
using ModelArchive.Application.Models;
using ModelArchive.Common;
using ModelArchive.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(KeyValueErrorContainer container)
        {

        }
    }
}
