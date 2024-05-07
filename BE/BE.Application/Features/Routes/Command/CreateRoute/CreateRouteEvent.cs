using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Command.CreateRoute;

public class CreateRouteEvent : BaseEvent
{
	public Route Route { get; }

	public CreateRouteEvent(Route route)
	{
		Route = route;
	}
}
