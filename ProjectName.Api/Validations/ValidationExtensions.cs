using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace ProjectName.Api.Validations
{
    public static class ValidationExtensions
    {
        public static string ToText(this IList<ValidationFailure> errors)
        {
            var text = new StringBuilder();
            foreach (var error in errors)
                text.AppendLine(error.ErrorMessage);

            return text.ToString();
        }
    }
}