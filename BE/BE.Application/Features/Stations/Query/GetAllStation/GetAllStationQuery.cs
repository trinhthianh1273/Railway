using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Query.GetAllStation;

public record GetAllStationQuery : IRequest<Result<List<GetAllStationDto>>>;

internal class GetAllStationQueryHandler : IRequestHandler<GetAllStationQuery, Result<List<GetAllStationDto>>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetAllStationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<List<GetAllStationDto>>> Handle(GetAllStationQuery request, CancellationToken cancellationToken)
	{
		var stations = await _unitOfWork.Repository<Station>().Entities
						.ProjectTo<GetAllStationDto>(_mapper.ConfigurationProvider)
						.ToListAsync(cancellationToken);

		return await Result<List<GetAllStationDto>>.SuccessAsync(stations);
	}
}
