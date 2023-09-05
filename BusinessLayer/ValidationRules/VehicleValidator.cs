using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class VehicleValidator: AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.VehicleTitle).NotEmpty().WithMessage("Araç Başlığı adı boş geçilemez");
            RuleFor(x => x.VehicleTitle).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }

    }
}
