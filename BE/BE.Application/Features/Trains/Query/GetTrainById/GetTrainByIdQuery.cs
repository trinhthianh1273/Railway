using AutoMapper;
using BE.Application.Features.Stations.Query.GetStationById;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Trains.Query.GetTrainById;

public record GetTrainByIdQuery : IRequest<Result<GetTrainByIdDto>>
{
	public int Id { get; set; }

	public GetTrainByIdQuery()
	{
	}

	public GetTrainByIdQuery(int id)
	{
		Id = id;
	}
}

internal class GetTrainByIdQueryHandler : IRequestHandler<GetTrainByIdQuery, Result<GetTrainByIdDto>>
{

	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetTrainByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<GetTrainByIdDto>> Handle(GetTrainByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Train>().GetByIdAsync(request.Id);
		var train = _mapper.Map<GetTrainByIdDto>(entity);
		return await Result<GetTrainByIdDto>.SuccessAsync(train);
	}
}
