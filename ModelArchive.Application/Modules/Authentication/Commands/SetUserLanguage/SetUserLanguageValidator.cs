using FluentValidation;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelArchive.Application.Modules.Authentication.Commands.SetUserLanguage
{
    public class SetUserLanguageValidator : AbstractValidator<SetUserLanguageCommand>
    {
        private readonly IOptions<LanguageOptions> _options;

        public SetUserLanguageValidator(IOptions<LanguageOptions> options)
        {
            _options = options;

            RuleFor(i => i.Language).NotEmpty();

            When(i => !string.IsNullOrEmpty(i.Language), () =>
            {
                RuleFor(i => i.Language).Must(SupportedLanguage)
                                        .WithMessage("Odabrani jezik nije podržan");
            });
        }

        public bool SupportedLanguage(string language)
        {
            return _options.Value.Languages.Contains(language);
        }
    }
}
