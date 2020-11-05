using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text;

namespace ModelArchive.Application.Resources
{
    /// <summary>
    /// Resource group
    /// </summary>
    public class FluentValidationMessages
    {
    }

    /// <summary>
    /// Fluent validation constants
    /// Concrete values are in FluentValidationMessages.{language}.resx files
    /// </summary>
    public static class FVC
    {
        public const string Email = "EmailValidator";
        public const string EmailUnique = "EmailUnique";
        public const string Card = "CreditCardValidator";
        public const string Empty = "EmptyValidator";
        public const string GreaterOrEqual = "GreaterThanOrEqualValidator";
        public const string Greater = "GreaterThanValidator";
        public const string LessOrEqual = "LessThanOrEqualValidator";
        public const string Less = "LessThenValidator";
        public const string Length = "LengthValidator";
        public const string Maximum = "MaximumLengthValidator";
        public const string Minimum = "MinimumLengthValidator";
        public const string NotEmpty = "NotEmptyValidator";
        public const string NotEqual = "NotEqualValidator";
        public const string NotNull = "NotNullValidator";
        public const string Null = "NullValidator";
        public const string Regex = "RegularExpressionValidator";
        public const string Equal = "EqualValidator";
        public const string UserNameUnique = "UserNameUnique";
        public const string Language = "SupportedLanguage";
    }
}
