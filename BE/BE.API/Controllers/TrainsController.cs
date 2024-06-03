using BE.Application.Features.Trains.Command.CreateTrain;
using BE.Application.Features.Trains.Query.GetAllTrain;
using BE.Application.Features.Trains.Query.GetTrainById;
using BE.Application.Features.Trains.Query.GetAllTrain;
using BE.Application.Features.Trains.Query.GetTrainById;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

public class TrainsController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public TrainsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	3
	[HttpGet]
	public async Task<ActionResult<Result<List<GetAllTrainDto>>>> Get()
	{
		return await _mediator.Send(new GetAllTrainQuery());
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Result<GetTrainByIdDto>>> GetById(int id)
	{
		return await _mediator.Send(new GetTrainByIdQuery(id));
	}

	[HttpPost]
	public async Task<ActionResult<Result<int>>> Create(CreateTrainCommand command)
	{
		return await _mediator.Send(command);
	}

}

