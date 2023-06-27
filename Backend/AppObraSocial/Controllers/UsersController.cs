using AppObraSocial.Models;
using AppObraSocial.Services.Users.Commands;
using AppObraSocial.Services.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppObraSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/save")]
        public async Task<User> saveUser([FromBody] SaveUserCommand saveUserCommand)
        {
            return await _mediator.Send(saveUserCommand);
        }
        [HttpGet]
        [Route("/get/{username}")]
        public async Task<User> getUserByUsername(string username)
        {
            return await _mediator.Send(new GetUserByUsernameQuery { Username = username });
        }
    }
}
