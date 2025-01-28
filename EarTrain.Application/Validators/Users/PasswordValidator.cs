using FluentValidation;
using System.Linq;

namespace EarTrain.Application.Validators.Users
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password=> password).NotEmpty()
                .MinimumLength(12)
                .WithMessage("Ваш старый пароль не должен быть пустым и меньше чем 12 букв!");

            When(password => !string.IsNullOrWhiteSpace(password), () =>
                RuleFor(password => password)
                    .Must(password => password.All(char.IsLower))
                    .WithMessage("Ваш пароль должен содержать исключительно маленькие буквы!")
            );
        }
    }
}
