using FluentValidation;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    public class LoginUserFormValidator : AbstractValidator<LoginUserFormCommand>
    {
        public LoginUserFormValidator()
        {
            RuleFor(i => i.Identifier).NotEmpty();
            RuleFor(i => i.Password).NotEmpty();
        }
    }
}
