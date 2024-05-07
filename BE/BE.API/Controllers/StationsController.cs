using BE.Application.Features.Stations.Command.CreateStation;
using BE.Application.Features.Stations.Command.DeleteStation;
using BE.Application.Features.Stations.Command.UpdateStation;
using BE.Application.Features.Stations.Query.GetAllStation;
using BE.Application.Features.Stations.Query.GetStationById;
using BE.Application.Features.Stations.Query.GetStationPagination;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

public class StationsController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public StationsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult<Result<List<GetAllStationDto>>>> Get()
	{
		return await _mediator.Send(new GetAllStationQuery());
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Result<GetStationByIdDto>>> GetById(int id)
	{
		return await _mediator.Send(new GetStationByIdQuery(id));
	}

	[HttpGet]
	[Route("page")]
	public async Task<ActionResult<PaginatedResult<GetStationPaginationDto>>> GetStationPagination([FromQuery] GetStationPaginationQuery query)
	{
		var validator = new GetStationPaginationValidator();

		var result = validator.Validate(query);
		if(result.IsValid)
		{
			return await _mediator.Send(query);
		}

		var errMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
		return BadRequest(errMessage);

	}

	[HttpPost]
	public async Task<ActionResult<Result<int>>> Create(CreateStationCommand command)
	{
		return await _mediator.Send(command);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<Result<int>>> Update(int id, UpdateStationCommand cmd)
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
		return await _mediator.Send(new DeleteStationCommand(id));
	}
}
