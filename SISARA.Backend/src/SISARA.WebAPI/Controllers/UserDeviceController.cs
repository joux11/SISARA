using MediatR;
using Microsoft.AspNetCore.Mvc;
using SISARA.Application.UseCases.UserDevices.Commands.CreateCommand;
using SISARA.Application.UseCases.UserDevices.Commands.DeleteCommand;
using SISARA.Application.UseCases.UserDevices.Commands.UpdateCommand;
using SISARA.Application.UseCases.UserDevices.Queries.GetAllQuery;
using SISARA.Application.UseCases.UserDevices.Queries.GetByIdQuery;

namespace SISARA.WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserDeviceController : ControllerBase
{
	private readonly IMediator _mediator;
	public UserDeviceController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var userDevices = await _mediator.Send(new GetAllUserDevicesQuery());
		return Ok(userDevices);
	}
	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetById(uint id)
	{
		var userDevice = await _mediator.Send(new GetUserDeviceByIdQuery{Id = id});
		return Ok(userDevice);
	}
	[HttpPost("Register")]
	public async Task<IActionResult> Register([FromBody] CreateUserDeviceCommand command)
	{
		var userDevice = await _mediator.Send(command);
		return Ok(userDevice);
	}
	[HttpPatch("Update")]
	public async Task<IActionResult> Update([FromBody] UpdateUserDeviceCommand command)
	{
		var response = await _mediator.Send(command);
		return Ok(response);		
	}
	[HttpDelete("Delete")]
	public async Task<IActionResult> Delete([FromBody] DeleteUserDeviceCommand command)
	{
		var response = await _mediator.Send(command);
		return Ok(response);
	}
}
