using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Features.Stations.Query.GetAllStation;
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

namespace BE.Application.Features.Trains.Query.GetAllTrain;

public record GetAllTrainQuery : IRequest<Result<List<GetAllTrainDto>>>;

internal class GetAllTrainQueryHandler : IRequestHandler<GetAllTrainQuery, Result<List<GetAllTrainDto>>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetAllTrainQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<List<GetAllTrainDto>>> Handle(GetAllTrainQuery request, CancellationToken cancellationToken)
	{
		var trains = await _unitOfWork.Repository<Train>().Entities
						.ProjectTo<GetAllTrainDto>(_mapper.ConfigurationProvider)
						.ToListAsync(cancellationToken);
		return await Result<List<GetAllTrainDto>>.SuccessAsync(trains);
	}
}
