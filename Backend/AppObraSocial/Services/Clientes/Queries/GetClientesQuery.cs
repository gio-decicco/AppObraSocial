using AppObraSocial.Data;
using AppObraSocial.Models;
using AppObraSocial.Models.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppObraSocial.Services.Clientes.Queries
{
    public class GetClientesQuery : IRequest<List<ClienteDTO>>
    {
    }

    public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, List<ClienteDTO>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public GetClientesQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                foreach(Cliente c in clientes)
                {
                    c.IdPlanNavigation = await _context.Planes.FirstOrDefaultAsync(x => x.IdPlan == c.IdPlan);
                }
                if (clientes.Count != 0)
                {
                    var clientesDTO = _mapper.Map<List<ClienteDTO>>(clientes);
                    return clientesDTO;
                }
                else
                {
                    throw new Exception("No existen clientes");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
