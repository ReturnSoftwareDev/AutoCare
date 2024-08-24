using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCare.WebAPI.Controllers
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
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginQuery userLoginQuery)
        {
            var result = await _mediator.Send(userLoginQuery);
            return Ok(result);
        }


    }
}
