using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class LoginValidator : AbstractValidator<Employee>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Mail).
                NotEmpty().WithMessage("Mail adresi boş olamaz").
                EmailAddress().WithMessage("Geçersiz mail adresi");


            RuleFor(p => p.Password).
              NotEmpty().WithMessage("Şifre boş olamaz.").
              NotNull().WithMessage("Şifre null olamaz.").
              MinimumLength(3).WithMessage("En az 3 karakter girilmeli");
        }
    }
}
