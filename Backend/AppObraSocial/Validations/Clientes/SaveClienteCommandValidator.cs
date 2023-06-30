using AppObraSocial.Services.Clientes.Commands;
using FluentValidation;

namespace AppObraSocial.Validations.Clientes
{
    public class SaveClienteCommandValidator : AbstractValidator<SaveClienteCommand>
    {
        public SaveClienteCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Surname).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Document).NotEmpty();
            RuleFor(c => c.IdPlan).NotEmpty();
        }   
    }
}
