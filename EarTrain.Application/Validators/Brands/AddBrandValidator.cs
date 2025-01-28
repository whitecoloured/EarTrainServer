using EarTrain.Application.CommandsAndQueries.Brands.AddBrand;
using FluentValidation;

namespace EarTrain.Application.Validators.Brands
{
    public class AddBrandValidator : AbstractValidator<AddBrandCommand>
    {
        public AddBrandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Имя бренда не должно быть пустым!");

            When(p=> !string.IsNullOrWhiteSpace(p.Name),()=>
                RuleFor(p=> p.Name)
                    .Must(p=> char.IsUpper(p[0]))
                    .WithMessage("Первая буква бренда должна начинаться с большой буквы!")
            );
        }
    }
}
