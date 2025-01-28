using EarTrain.Application.CommandsAndQueries.Tasks;
using FluentValidation;

namespace EarTrain.Application.Validators.Tasks
{
    public class TaskValidator : AbstractValidator<TaskCommand>
    {
        public TaskValidator()
        {
            RuleFor(p => p.SoundCategory)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Установите правильную категорию звука!");

            RuleFor(p => p.TaskCategory)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Установите правильную категорию задания!");

            RuleFor(p => p.Answer)
                .NotEmpty()
                .WithMessage("Установите правильный ответ задания!");
        }
    }
}
