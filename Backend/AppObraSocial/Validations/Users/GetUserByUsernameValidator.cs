using AppObraSocial.Services.Users.Queries;
using FluentValidation;

namespace AppObraSocial.Validations.Users
{
    public class GetUserByUsernameValidator : AbstractValidator<GetUserByUsernameQuery>
    {
        public GetUserByUsernameValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
        }
    }
}
