using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using ModelArchive.Application.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelArchive.Application.Modules.Authentication.Commands.SetUserLanguage
{
    public class SetUserLanguageValidator : AbstractValidator<SetUserLanguageCommand>
    {
        private readonly IOptions<LanguageOptions> _options;

        public SetUserLanguageValidator(IOptions<LanguageOptions> options,
            IStringLocalizer<FluentValidationMessages> localizer)
        {
            _options = options;

            RuleFor(i => i.Language).NotEmpty()
                .WithMessage(localizer[FVC.NotEmpty].Value);
            When(i => !string.IsNullOrEmpty(i.Language), () =>
            {
                RuleFor(i => i.Language).Must(SupportedLanguage)
                    .WithMessage(localizer[FVC.Language].Value);
            });
        }

        public bool SupportedLanguage(string language)
        {
            return _options.Value.Languages.Contains(language);
        }
    }
}
