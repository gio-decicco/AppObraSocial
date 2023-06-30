using AppObraSocial.Data;
using AppObraSocial.Models;
using AppObraSocial.Validations.Clientes;
using AutoMapper;
using MediatR;

namespace AppObraSocial.Services.Clientes.Commands
{
    public class SaveClienteCommand : IRequest<Cliente>
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Document { get; set; }

        public int IdPlan { get; set; }
    }

    public class SaveClienteCommandHandler : IRequestHandler<SaveClienteCommand, Cliente>
    {
        private readonly ApplicationContext _context;
        private readonly SaveClienteCommandValidator _validator;
        private readonly IMapper _mapper;

        public SaveClienteCommandHandler(ApplicationContext context, SaveClienteCommandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Cliente> Handle(SaveClienteCommand request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                cliente.IdPlanNavigation = await _context.Planes.FindAsync(request.IdPlan);

                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch
            {
                throw;
            }
        }
    }
}
