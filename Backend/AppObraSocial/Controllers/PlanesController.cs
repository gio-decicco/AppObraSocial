using AppObraSocial.Models;
using AppObraSocial.Services.Planes.Commands;
using AppObraSocial.Services.Planes.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppObraSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("savePlan")]
        public async Task<Plane> savePlan([FromBody] SavePlanCommand savePlanCommand)
        {
            return await _mediator.Send(savePlanCommand);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<Plane>> getPlanes()
        {
            return await _mediator.Send(new GetPlanesCommand());
        }
    }
}
