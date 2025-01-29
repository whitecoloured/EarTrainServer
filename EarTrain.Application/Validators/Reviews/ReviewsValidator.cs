using EarTrain.Application.CommandsAndQueries.Reviews;
using FluentValidation;

namespace EarTrain.Application.Validators.Reviews
{
    public class ReviewsValidator: AbstractValidator<ReviewCommand>
    {
        public ReviewsValidator()
        {
            RuleFor(p => p.ReviewDesc)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Ваш отзыв не должен быть пустым и содержать более чем 300 букв!");

            RuleFor(p => p.Mark)
                .NotEmpty()
                .Must(p => p > 0 && p <= 5)
                .WithMessage("Ваша оценка должна быть от 1 до 5!");
        }
    }
}
