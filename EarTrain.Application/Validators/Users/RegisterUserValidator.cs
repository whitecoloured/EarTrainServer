using EarTrain.Application.CommandsAndQueries.Users.Register;
using FluentValidation;
using System.Linq;

namespace EarTrain.Application.Validators.Users
{
    internal class RegisterUserValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(p => p.Email).NotEmpty()
                .EmailAddress()
                .WithMessage("Ваша электронная почта не должна быть пустой!");

            RuleFor(p => p.Password).SetValidator(new PasswordValidator());

            RuleFor(p => p.Login).NotEmpty()
                .MinimumLength(8)
                .WithMessage("Ваш логин не должен быть пустым и меньше чем 8 букв!");

            When(p => !string.IsNullOrWhiteSpace(p.Login), () =>
                RuleFor(p => p.Login)
                    .Must(p => p.All(char.IsLower))
                    .WithMessage("Ваш логин должен содержать исключительно маленькие буквы!")
            );

            RuleFor(p => p.Address).SetValidator(new AddressValidator());
        }
    }
}
