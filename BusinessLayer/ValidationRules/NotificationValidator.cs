using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.NotificationType).NotEmpty().WithMessage("Bildirim Türü  boş geçilemez");
            RuleFor(x => x.NotificationType).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");

        }
    }
}
