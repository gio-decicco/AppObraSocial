using AppObraSocial.Services.Users.Commands;
using FluentValidation;

namespace AppObraSocial.Validations.Users
{
    public class SaveUserValidator : AbstractValidator<SaveUserCommand>
    {
        public SaveUserValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
