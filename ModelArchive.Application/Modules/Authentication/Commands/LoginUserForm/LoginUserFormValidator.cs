using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Localization;
using ModelArchive.Application.Resources;

namespace ModelArchive.Application.Modules.Authentication.Commands.LoginUserForm
{
    public class LoginUserFormValidator : AbstractValidator<LoginUserFormCommand>
    {
        public LoginUserFormValidator(IStringLocalizer<FluentValidationMessages> localizer)
        {
            RuleFor(i => i.Identifier).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value);

            RuleFor(i => i.Password).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value);
        }
    }
}
