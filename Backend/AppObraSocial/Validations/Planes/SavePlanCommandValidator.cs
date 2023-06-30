using AppObraSocial.Services.Planes.Commands;
using FluentValidation;

namespace AppObraSocial.Validations.Planes
{
    public class SavePlanCommandValidator : AbstractValidator<SavePlanCommand>
    {
        public SavePlanCommandValidator()
        {
            RuleFor(p => p.Descripcion).NotEmpty();
            RuleFor(p => p.Cuota).NotEmpty();
        }
    }
}
