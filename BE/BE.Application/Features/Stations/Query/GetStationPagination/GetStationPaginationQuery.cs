using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Extensions;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Query.GetStationPagination;

public record GetStationPaginationQuery : IRequest<PaginatedResult<GetStationPaginationDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }

	public GetStationPaginationQuery()
	{
	}

	public GetStationPaginationQuery(int pageNumber, int pageSize)
	{
		PageNumber = pageNumber;
		PageSize = pageSize;
	}
}

internal class GetStationPaginationQueryHandler : IRequestHandler<GetStationPaginationQuery, PaginatedResult<GetStationPaginationDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetStationPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<PaginatedResult<GetStationPaginationDto>> Handle(GetStationPaginationQuery request, CancellationToken cancellationToken)
	{
		return await _unitOfWork.Repository<Station>().Entities
				.OrderBy(x => x.StationName)
				.ProjectTo<GetStationPaginationDto>(_mapper.ConfigurationProvider)
				.ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
		
	}
}
