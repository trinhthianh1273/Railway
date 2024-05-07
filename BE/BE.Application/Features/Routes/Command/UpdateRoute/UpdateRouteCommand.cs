﻿using AutoMapper;
using BE.Application.Common.Mappings;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Command.UpdateRoute;

public record UpdateRouteCommand : IRequest<Result<int>>, IMapFrom<Route>
{
	public int Id { get; set; }
	public string RouteName { get; set; }
	public int DepartureStation { get; set; }
	public int DestinationStation { get; set; }
	public decimal RouteFare { get; set; }
}

internal class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateRouteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
	{
		var route = new Route()
		{
			Id = request.Id,
			RouteName = request.RouteName,
			DepartureStation = request.DepartureStation,
			DestinationStation = request.DestinationStation,
			RouteFare = request.RouteFare
		};

		await _unitOfWork.Repository<Route>().UpdateAsync(route);
		route.AddDomainEvent(new RouteUpdatedEvent(route));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(route.Id, "Route Updated.");
	}
}
