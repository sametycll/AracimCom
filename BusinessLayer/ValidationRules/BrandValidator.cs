using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka adı boş geçilemez");
            RuleFor(x => x.BrandName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.BrandName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");
       
        }
    }
}
