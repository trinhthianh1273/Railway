using BE.Application.Common.Mappings;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Routes.Query.GetRouteById;

public class GetRouteByIdDto : IMapFrom<Route>
{
	public int Id { get; set; }
	public string RouteName { get; set; }
	public string DepartureStationName { get; set; }
	public string DestinationStationName { get; set; }
	public decimal RouteFare { get; set; }
}
