using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Trains.Command.CreateTrain;

public class TrainCreatedEvents : BaseEvent
{
	public Train Train { get; }

	public TrainCreatedEvents(Train train)
	{
		Train = train;
	}
}
