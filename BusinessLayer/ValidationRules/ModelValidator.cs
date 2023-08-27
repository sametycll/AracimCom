using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ModelValidator: AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Model adı boş geçilemez");
            RuleFor(x => x.ModelName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }
    }
}
