using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Command.UpdateStation;

public class StationUpdatedEvent : BaseEvent
{
	public Station Station { get; set; }

	public StationUpdatedEvent(Station station)
	{
		Station = station;
	}
}
