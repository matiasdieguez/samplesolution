using System;
using System.Linq;
using FluentValidation;
using ProjectName.Dto;
using ProjectName.Localization;

namespace ProjectName.Api.Validations
{

  public class UserValidation : AbstractValidator<UserDto>
    {
        public UserValidation()
        {
            RuleFor(item => item.Username)
                .NotEmpty()
                .WithMessage(Localizer.Get(Resources.Required));

            RuleFor(item => item.Username)
                .Must(BeValidUserName)
                .WithMessage(Localizer.Get(Resources.UsernameMustBeValid));
        }

        private bool BeValidUserName(string arg)
        {
            if (string.IsNullOrEmpty(arg) ||
                string.IsNullOrWhiteSpace(arg) ||
                arg.Contains(" "))
                return false;

            var array = arg.ToCharArray();

            if (!array.Any(char.IsControl) &&
                !array.Any(char.IsPunctuation) &&
                !array.Any(char.IsSeparator) &&
                !array.Any(c => char.IsSymbol(c)))
                return true;
            else
                return false;
        }
    }
}