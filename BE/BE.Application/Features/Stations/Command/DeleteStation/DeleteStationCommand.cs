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

namespace BE.Application.Features.Stations.Command.DeleteStation;

public record DeleteStationCommand : IRequest<Result<int>>, IMapFrom<Station>
{
	public int Id { get; set; }
	public DeleteStationCommand()
	{
	}

	public DeleteStationCommand(int id)
	{
		Id = id;
	}
}

internal class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteStationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
	{
		var station = await _unitOfWork.Repository<Station>().GetByIdAsync(request.Id);
		if(station == null)
		{
			return await Result<int>.FailureAsync("Station Not Found");
		} else
		{
			await _unitOfWork.Repository<Station>().DeleteAsync(station);
			station.AddDomainEvent(new StationDeletedEvent(station));

			await _unitOfWork.Save(cancellationToken);
			return await Result<int>.SuccessAsync(station.Id, "Station Deleted");
		}

		throw new NotImplementedException();
	}
}
