using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ad Soyad adı boş geçilemez");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }
    }
}
