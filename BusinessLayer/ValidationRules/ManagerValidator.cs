using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ManagerValidator : AbstractValidator<Manager>
    {
        public ManagerValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }
    }
}
