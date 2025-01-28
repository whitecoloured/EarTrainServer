using EarTrain.Core.Models;
using FluentValidation;

namespace EarTrain.Application.Validators.Users
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.StreetType).NotEmpty()
                .IsInEnum()
                .WithMessage("Установите корректный тип улицы!");

            RuleFor(p => p.StreetName).NotEmpty()
                .WithMessage("Имя улицы не должно быть пустым!");

            When(p => !string.IsNullOrWhiteSpace(p.StreetName), () =>
                RuleFor(p => p.StreetName)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("Первая буква имени улицы должна быть заглавной!")
            );

            RuleFor(p => p.StreetNumber).NotEmpty()
                .WithMessage("Номер улицы не должен быть пустым!");

            When(p => !string.IsNullOrWhiteSpace(p.StreetNumber), () =>
                {
                    RuleFor(p => p.StreetNumber)
                        .Must(p => "0123456789".Contains(p))
                        .WithMessage("Номер улицы должен содержать цифры!");

               }
            );
        }
    }
}
