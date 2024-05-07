using BE.Application.Features.Stations.Command.CreateStation;
using BE.Application.Features.Stations.Command.DeleteStation;
using BE.Application.Features.Stations.Command.UpdateStation;
using BE.Application.Features.Stations.Query.GetAllStation;
using BE.Application.Features.Stations.Query.GetStationById;
using BE.Application.Features.Users.Command.CreateUser;
using BE.Application.Features.Users.Command.DeleteUser;
using BE.Application.Features.Users.Command.UpdateUser;
using BE.Application.Features.Users.Query.GetAllUser;
using BE.Application.Features.Users.Query.GetUserById;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

public class UsersController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public UsersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult<Result<List<GetAllUserDto>>>> Get()
	{
		return await _mediator.Send(new GetAllUserQuery());
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Result<GetUserByIdDto>>> GetById(int id)
	{
		return await _mediator.Send(new GetUserByIdQuery(id));
	}


	[HttpPost]
	public async Task<ActionResult<Result<int>>> Create(CreateUserCommand command)
	{
		return await _mediator.Send(command);
	}
	[HttpPut("{id}")]
	public async Task<ActionResult<Result<int>>> Update(int id, UpdateUserCommand cmd)
	{
		if (id != cmd.Id)
		{
			return BadRequest();
		}
		return await _mediator.Send(cmd);
	}


	[HttpDelete("{id}")]
	public async Task<ActionResult<Result<int>>> Delete(int id)
	{
		return await _mediator.Send(new DeleteUserCommand(id));
	}


}
