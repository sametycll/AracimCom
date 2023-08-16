using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SeriesValidator:AbstractValidator<Series>
    {
        public SeriesValidator()
        {
            RuleFor(x => x.SeriesName).NotEmpty().WithMessage("Seri adı boş geçilemez");            
            RuleFor(x => x.SeriesName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }
    }
}
