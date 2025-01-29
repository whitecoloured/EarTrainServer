using EarTrain.Application.CommandsAndQueries.Users.EditPassword;
using FluentValidation;

namespace EarTrain.Application.Validators.Users
{
    public class EditPasswordValidator : AbstractValidator<PasswordsModel>
    {
        public EditPasswordValidator()
        {
            RuleFor(p=> p.OldPassword).SetValidator(new PasswordValidator())
                .WithMessage("Установите валидный старый пароль!");

            RuleFor(p=> p.NewPassword).SetValidator(new PasswordValidator())
                .WithMessage("Установите валидный новый пароль!");
        }
    }
}
