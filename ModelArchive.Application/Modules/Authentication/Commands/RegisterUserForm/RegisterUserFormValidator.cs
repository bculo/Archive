using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm
{
    public class RegisterUserFormValidator : AbstractValidator<RegisterUserFormCommand>
    {
        private readonly IUserRepository _repo;
        private readonly AuthenticationOptions _options;

        public RegisterUserFormValidator(IUserRepository repo, 
            IOptions<AuthenticationOptions> options,
            IStringLocalizer<FluentValidationMessages> localizer)
        {
            _repo = repo;
            _options = options.Value;

            //Username section
            RuleFor(i => i.UserName).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value);
            When(i => !string.IsNullOrEmpty(i.UserName), () =>
            {
                RuleFor(i => i.UserName).MustAsync(UserNameUnique)
                    .WithMessage(localizer[FVC.UserNameUnique].Value);
            });

            //Password section
            RuleFor(i => i.Password).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value)
                .MinimumLength(_options.Password.RequiredLength)
                .WithMessage(localizer[FVC.Minimum].Value);
                
            //Repeat password section
            RuleFor(i => i.RepeatPassword).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value)
                .Equal(t => t.Password)
                .WithMessage(localizer[FVC.Equal].Value);

            //Email section
            RuleFor(i => i.Email).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value)
                .EmailAddress()
                .WithMessage(localizer[FVC.Email].Value);
            When(i => !string.IsNullOrEmpty(i.Email), () =>
            {
                RuleFor(i => i.Email).MustAsync(EmailUnique)
                    .WithMessage(localizer[FVC.EmailUnique].Value);
            });
        }

        public async Task<bool> EmailUnique(string email, CancellationToken token = default)
        {
            var user = await _repo.GetArchiveUser(email);

            if (user is null)
                return true;

            return false;
        }

        public async Task<bool> UserNameUnique(string userName, CancellationToken token = default)
        {
            var user = await _repo.GetArchiveUser(userName);

            if (user is null)
                return true;

            return false;
        }
    }
}
