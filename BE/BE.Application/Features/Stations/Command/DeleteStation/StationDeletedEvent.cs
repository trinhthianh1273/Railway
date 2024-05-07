using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Command.DeleteStation;

public class StationDeletedEvent : BaseEvent
{
	public Station Station { get; set; }

	public StationDeletedEvent(Station station)
	{
		Station = station;
	}
}
