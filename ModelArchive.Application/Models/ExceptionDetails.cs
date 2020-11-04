using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Models
{
    public class ExceptionDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public object Errors { get; set; }
    }
}
