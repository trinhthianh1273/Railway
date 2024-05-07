using AutoMapper;
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

namespace BE.Application.Features.Routes.Command.DeleteRoute;

public record DeleteRouteCommand : IRequest<Result<int>>, IMapFrom<Route>
{
	public int Id { get; set; }

	public DeleteRouteCommand()
	{
	}

	public DeleteRouteCommand(int id)
	{
		Id = id;
	}
}

internal class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteRouteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
	{
		var route = await _unitOfWork.Repository<Route>().GetByIdAsync(request.Id);
		if (route == null)
		{
			return await Result<int>.FailureAsync("Route Not Found");
		}

		await _unitOfWork.Repository<Route>().DeleteAsync(route);
		route.AddDomainEvent(new RouteDeletedEvent(route));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(route.Id, "Route Deleted");
	}
}
