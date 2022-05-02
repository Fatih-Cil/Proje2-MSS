using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.EmployeeName).
                NotEmpty().WithMessage("Çalıaan adı boş olamaz");

            RuleFor(p => p.EmployeeSurname).
              NotEmpty().WithMessage("Çalışan soyadı boş olamaz.");

            RuleFor(p => p.Mail).
              NotEmpty().WithMessage("Mail boş olamaz.");

            RuleFor(p => p.Mail).
              EmailAddress().WithMessage("Geçersiz mail adresi");

            RuleFor(p => p.Password).
              NotEmpty().WithMessage("Şifre girmek zorunludur.");

            RuleFor(p => p.RegisterDate).
              NotEmpty().WithMessage("Giriş tarihi giriniz");

            RuleFor(p => p.RegisterNumber).
              NotEmpty().WithMessage("Çalışana ait kart numarasını giriniz");
        }
    }
}
