using AppObraSocial.Data;
using AppObraSocial.Models;
using AppObraSocial.Validations.Planes;
using AutoMapper;
using MediatR;

namespace AppObraSocial.Services.Planes.Commands
{
    public class SavePlanCommand : IRequest<Plane>
    {
        public string Descripcion { get; set; } = null!;

        public double Cuota { get; set; }
    }

    public class SavePlanCommandHandler : IRequestHandler<SavePlanCommand, Plane>
    {
        private readonly ApplicationContext _context;
        private readonly SavePlanCommandValidator _validator;
        private readonly IMapper _mapper;

        public SavePlanCommandHandler(ApplicationContext context, SavePlanCommandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Plane> Handle(SavePlanCommand request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);
            try
            {
                var plan = _mapper.Map<Plane>(request);
                await _context.Planes.AddAsync(plan);
                await _context.SaveChangesAsync();
                return plan;
            }
            catch
            {
                throw;
            }
        }
    }
}
