using BE.Application.Features.Routes.Command.CreateRoute;
using BE.Application.Features.Routes.Command.DeleteRoute;
using BE.Application.Features.Routes.Command.UpdateRoute;
using BE.Application.Features.Routes.Query.GetAllRoute;
using BE.Application.Features.Routes.Query.GetRouteById;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

public class RoutesController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public RoutesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult<Result<List<GetAllRouteDto>>>> Get()
	{
		return await _mediator.Send(new GetAllRouteQuery());
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Result<GetRouteByIdDto>>> GetById(int id)
	{
		return await _mediator.Send(new GetRouteByIdQuery { Id = id });
	}

	[HttpPost]
	public async Task<ActionResult<Result<int>>> Create(CreateRouteCommand cmd)
	{
		return await _mediator.Send(cmd);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Result<int>>> Update(int id, UpdateRouteCommand cmd)
	{
		if(id != cmd.Id)
		{
			return BadRequest();
		}
		return await _mediator.Send(cmd);
	}
	[HttpDelete("{id}")]	
	public async Task<ActionResult<Result<int>>> Delete(int id)
	{
		return await _mediator.Send(new DeleteRouteCommand(id));
	}
	
}
