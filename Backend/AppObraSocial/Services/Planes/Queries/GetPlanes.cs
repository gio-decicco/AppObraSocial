using AppObraSocial.Data;
using AppObraSocial.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppObraSocial.Services.Planes.Queries
{
    public class GetPlanesCommand : IRequest<List<Plane>>
    {

    }

    public class GetPlanesCommandHandler : IRequestHandler<GetPlanesCommand, List<Plane>>
    {
        private readonly ApplicationContext _context;

        public GetPlanesCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Plane>> Handle(GetPlanesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var planes = await _context.Planes.ToListAsync();
                if (planes.Count != 0)
                {
                    return planes;
                }
                else
                {
                    throw new Exception("No hay planes para mostrar");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
