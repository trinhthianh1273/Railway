using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Command.CreateStation;

public class StationCreatedEvents : BaseEvent
{
	public Station Station { get; }

	public StationCreatedEvents(Station station)
	{
		Station = station;
	}
}
