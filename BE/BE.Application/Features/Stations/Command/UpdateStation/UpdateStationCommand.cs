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

namespace BE.Application.Features.Stations.Command.UpdateStation;

public record UpdateStationCommand : IRequest<Result<int>>
{
	public int Id { get; set; }
	public string StationName { get; set;}
}

internal class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateStationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(UpdateStationCommand request, CancellationToken cancellationToken)
	{
		var station = await _unitOfWork.Repository<Station>().GetByIdAsync(request.Id);
		if(station != null)
		{
			station.StationName = request.StationName;

			await _unitOfWork.Repository<Station>().UpdateAsync(station);
			station.AddDomainEvent(new StationUpdatedEvent(station));

			await _unitOfWork.Save(cancellationToken);
			return await Result<int>.SuccessAsync(station.Id, "Station updated");
		} else
		{
			return await Result<int>.FailureAsync("Station Not Found");
		}
	}
}
