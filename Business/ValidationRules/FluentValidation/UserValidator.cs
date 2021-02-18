using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(3);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(RegexControl).WithMessage("Mail formatı uygun değil");

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
        }

        private bool RegexControl(string arg)
        {
           Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
           Match match = regex.Match(arg);
           if (match.Success)
               return true;
           else
               return false;
        }
    }
}
