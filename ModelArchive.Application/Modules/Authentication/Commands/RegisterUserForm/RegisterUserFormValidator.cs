using FluentValidation;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Modules.Authentication.Commands.RegisterUserForm
{
    public class RegisterUserFormValidator : AbstractValidator<RegisterUserFormCommand>
    {
        private readonly IUserRepository _repo;
        private readonly AuthenticationOptions _options;

        public RegisterUserFormValidator(IUserRepository repo, 
            IOptions<AuthenticationOptions> options)
        {
            _repo = repo;
            _options = options.Value;

            RuleFor(i => i.UserName).NotEmpty();
            /*
            When(i => !string.IsNullOrEmpty(i.UserName), () =>
            {
                RuleFor(i => i.UserName).MustAsync(UserNameUnique).WithMessage("UserName is already taken");
            });
            */

            RuleFor(i => i.Password).NotEmpty()
                .MinimumLength(_options.Password.RequiredLength);

            RuleFor(i => i.RepeatPassword).NotEmpty()
                .Must((model, pass) => model.Password == pass)
                .WithMessage("Repeat password must be same as Password field");

            RuleFor(i => i.Email).NotEmpty().EmailAddress();
            /*
            When(i => !string.IsNullOrEmpty(i.Email), () =>
            {
                RuleFor(i => i.Email).MustAsync(EmailUnique).WithMessage("Email is already taken");
            });
            */
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
