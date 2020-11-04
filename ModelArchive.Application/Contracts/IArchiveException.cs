using Microsoft.AspNetCore.Mvc;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Contracts
{
    public interface IArchiveException
    {
        ExceptionDetails GetDetails();
    }
}
