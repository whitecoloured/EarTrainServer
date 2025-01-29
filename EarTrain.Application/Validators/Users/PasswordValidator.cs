using FluentValidation;
using System.Linq;

namespace EarTrain.Application.Validators.Users
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password).NotEmpty()
                .MinimumLength(12);

            When(password => !string.IsNullOrWhiteSpace(password), () =>
                RuleFor(password => password)
                    .Must(password => !password.Contains(' '))
                    .Must(password => password.All(char.IsLower))
            );
        }
    }
}
