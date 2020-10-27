using MediatR;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    public class LoginUserFormCommand : IRequest<Response<Unit>>
    {
        public string Identifier { get; set; }
        public string Password { get; set; }
    }
}
