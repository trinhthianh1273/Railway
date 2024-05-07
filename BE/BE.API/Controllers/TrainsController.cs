using BE.Application.Features.Stations.Query.GetAllStation;
using BE.Application.Features.Trains.Query.GetAllTrain;
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
	[HttpGet]
	public async Task<ActionResult<Result<List<GetAllTrainDto>>>> Get()
	{
		return await _mediator.Send(new GetAllTrainQuery());
	}

}

