using MediatR;
using Microsoft.AspNetCore.Mvc;
using SISARA.Application.UseCases.Users.Commands.CreateCommand;
using SISARA.Application.UseCases.Users.Commands.DeleteCommand;
using SISARA.Application.UseCases.Users.Commands.UpdateCommand;
using SISARA.Application.UseCases.Users.Queries.GetAllQuery;
using SISARA.Application.UseCases.Users.Queries.GetByIdQuery;

namespace SISARA.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(uint id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
