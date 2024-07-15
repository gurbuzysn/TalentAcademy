using FluentValidation;
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
                    .WithMessage("Kullanıcı adı boş olamaz")
                .EmailAddress()
                    .WithMessage("Lütfen geçerli bir email adresi giriniz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Parola alanı boş olamaz");
        }
    }
}
