using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Command.DeleteRoute;

public class RouteDeletedEvent : BaseEvent
{
	public Route Route { get; }

	public RouteDeletedEvent(Route route)
	{
		Route = route;
	}
}
