using MediatR;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Modules.Authentication.Commands.Logout
{
    public class LogoutCommand : IRequest<Response<Unit>>
    {
    }
}
