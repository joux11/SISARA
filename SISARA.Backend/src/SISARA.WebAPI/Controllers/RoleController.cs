using MediatR;
using Microsoft.AspNetCore.Mvc;
using SISARA.Application.UseCases.Roles.Commands.CreateCommand;
using SISARA.Application.UseCases.Roles.Commands.DeleteCommand;
using SISARA.Application.UseCases.Roles.Commands.UpdateCommand;
using SISARA.Application.UseCases.Roles.Queries.GetAllQuery;
using SISARA.Application.UseCases.Roles.Queries.GetByIdQuery;

namespace SISARA.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllRoleQuery());
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(uint id)
        {
            var response = await _mediator.Send(new GetByIdRoleQuery() { Id = id });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterRole([FromBody] CreateRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRol([FromBody] DeleteRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
