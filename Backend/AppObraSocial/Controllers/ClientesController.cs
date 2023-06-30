using AppObraSocial.Models;
using AppObraSocial.Models.Dtos;
using AppObraSocial.Services.Clientes.Commands;
using AppObraSocial.Services.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppObraSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<ClienteDTO>> getClientes()
        {
            return await _mediator.Send(new GetClientesQuery());
        }

        [HttpPost]
        [Route("saveCliente")]
        public async Task<Cliente> saveCliente([FromBody] SaveClienteCommand saveClienteCommand)
        {
            return await _mediator.Send(saveClienteCommand);
        }
    }
}
