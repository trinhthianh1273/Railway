using AutoMapper;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Query.GetStationById;

public record GetStationByIdQuery : IRequest<Result<GetStationByIdDto>>
{
	public GetStationByIdQuery()
	{
	}

	public int Id { get; set; }

	public GetStationByIdQuery(int id)
	{
		Id = id;
	}
}

internal class GetStationByIdQueryHandler : IRequestHandler<GetStationByIdQuery, Result<GetStationByIdDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetStationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<GetStationByIdDto>> Handle(GetStationByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Station>().GetByIdAsync(request.Id);
		var station = _mapper.Map<GetStationByIdDto>(entity);
		return await Result<GetStationByIdDto>.SuccessAsync(station);
	}
}
