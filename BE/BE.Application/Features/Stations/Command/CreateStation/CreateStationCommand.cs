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

namespace BE.Application.Features.Stations.Command.CreateStation

{
	public record CreateStationCommand : IRequest<Result<int>>, IMapFrom<Station>
	{
		public string StationName { get; set; }
	}

	internal class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, Result<int>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateStationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Result<int>> Handle(CreateStationCommand request, CancellationToken cancellationToken)
		{
			var station = new Station()
			{
				StationName = request.StationName
			};

			await _unitOfWork.Repository<Station>().AddAsync(station);
			station.AddDomainEvent(new StationCreatedEvents(station));

			await _unitOfWork.Save(cancellationToken);
			return await Result<int>.SuccessAsync(station.Id, "Station Created");
		}
	}
}
