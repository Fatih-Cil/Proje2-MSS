using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(p => p.ShopName).
                NotEmpty().WithMessage("Şube adı boş olamaz");


            RuleFor(p => p.Opening).
              NotEmpty().WithMessage("Açılış saati girmek zorunludur.");

            RuleFor(p => p.Closing).
              NotEmpty().WithMessage("Kapanış saati girmek zorunludur.");

            RuleFor(p => p.Locasion).
              NotEmpty().WithMessage("Lokasyon girmek zorunludur.");
        }
    }
}
