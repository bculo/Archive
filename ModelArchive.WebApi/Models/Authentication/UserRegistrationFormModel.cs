using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelArchive.WebApi.Models.Authentication
{
    public class UserRegistrationFormModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }
    }
}
