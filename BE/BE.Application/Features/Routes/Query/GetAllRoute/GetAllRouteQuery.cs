using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Query.GetAllRoute;

public record GetAllRouteQuery : IRequest<Result<List<GetAllRouteDto>>>;

internal class GetAllRouteQueryHandle : IRequestHandler<GetAllRouteQuery, Result<List<GetAllRouteDto>>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetAllRouteQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<List<GetAllRouteDto>>> Handle(GetAllRouteQuery request, CancellationToken cancellationToken)
	{
		var routes = await _unitOfWork.Repository<Route>().Entities
							.ProjectTo<GetAllRouteDto>(_mapper.ConfigurationProvider)
							.ToListAsync(cancellationToken);
		return await Result<List<GetAllRouteDto>>.SuccessAsync(routes);
	}
}
