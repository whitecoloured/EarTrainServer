using EarTrain.Application.CommandsAndQueries.Products;
using FluentValidation;
using System;

namespace EarTrain.Application.Validators.Products
{
    public class ProductsValidator : AbstractValidator<ProductCommand>
    {
        public ProductsValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Имя продукта не должно быть пустым!");

            When(p => !string.IsNullOrWhiteSpace(p.Name), () =>
                RuleFor(p => p.Name)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("Имя продукта должно начинаться с большой буквы!")
            );

            RuleFor(p => p.Desc)
                .NotEmpty()
                .WithMessage("Описание продукта не должно быть пустым!");

            When(p => !string.IsNullOrWhiteSpace(p.Desc), () =>
                RuleFor(p => p.Desc)
                    .Must(p => char.IsUpper(p[0]))
                    .WithMessage("Описание продукта должно начинаться с большой буквы!")
            );

            RuleFor(p => p.BrandID)
                .NotEmpty()
                .Must(p => p != Guid.Empty)
                .WithMessage("Бренд продукта не должен быть пустым!");

            RuleFor(p => p.Category)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Категория продукта должна быть установлена правильно!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .Must(p => p >= 100 || p <= 99999)
                .WithMessage("Цена продукта должна быть в диапозоне значений от 100 до 99999!");

            When(p => p.Characteristics.Count > 0, () =>
                RuleForEach(p => p.Characteristics)
                    .NotEmpty()
                    .Must(p => char.IsUpper(p.Key[0]) && char.IsUpper(p.Value[0]))
                    .WithMessage("Название и описание характеристики должны начинаться с большой буквы!")
            );

        }
    }
}
