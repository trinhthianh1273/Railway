using AutoMapper;
using BE.Application.Common.Mappings;
using BE.Application.Features.Trains.Command.CreateTrain;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Trains.Command.CreateTrain;

public record CreateTrainCommand : IRequest<Result<int>>, IMapFrom<Train>
{
	public string TrainName { get; set; }
}

internal class CreateTrainCommandHandler : IRequestHandler<CreateTrainCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateTrainCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(CreateTrainCommand request, CancellationToken cancellationToken)
	{
		var Train = new Train()
		{
			TrainName = request.TrainName
		};

		await _unitOfWork.Repository<Train>().AddAsync(Train);
		Train.AddDomainEvent(new TrainCreatedEvents(Train));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(Train.Id, "Train Created");
	}
}
