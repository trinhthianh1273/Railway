using BE.Application.Features.Stations.Query.GetAllStation;
using BE.Application.Features.Stations.Query.GetStationById;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

public class SampleController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public SampleController(IMediator mediator)
	{
		_mediator = mediator;
	}
}
