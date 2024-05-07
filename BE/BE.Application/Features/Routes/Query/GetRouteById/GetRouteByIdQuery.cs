using AutoMapper;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Query.GetRouteById;

public record GetRouteByIdQuery : IRequest<Result<GetRouteByIdDto>>
{
	public int Id { get; set; }

	public GetRouteByIdQuery()
	{
	}

	public GetRouteByIdQuery(int id)
	{
		Id = id;
	}
}

internal class GetRouteByIdQueryHandle : IRequestHandler<GetRouteByIdQuery, Result<GetRouteByIdDto>> 
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetRouteByIdQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<GetRouteByIdDto>> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Route>().GetByIdAsync(request.Id);
		var route = _mapper.Map<GetRouteByIdDto>(entity);
		return await Result<GetRouteByIdDto>.SuccessAsync(route);
	}
}
