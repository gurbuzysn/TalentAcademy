using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Queries.Auth;

namespace TalentAcademy.Application.Validators.Auth
{
    public class CheckUserQueryRequestValidator : AbstractValidator<CheckUserQueryRequest>
    {
        public CheckUserQueryRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Kullanıcı adı boş olamazzzzzzzzzzzzzz")
                .EmailAddress()
                    .WithMessage("Lütfen geçerli bir email adresi giriniz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Parola alanı boş olamaz");
        }
    }
}
