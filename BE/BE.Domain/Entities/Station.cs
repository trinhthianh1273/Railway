using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Station : BaseAuditableEntity
{
	public string StationName { get; set; }
	[JsonIgnore]
	public ICollection<Route>? RouteDepartureStationNavigations { get; set; } = new List<Route>();

	[JsonIgnore]
	public ICollection<Route>? RouteDestinationStationNavigations { get; set; } = new List<Route>();
	public Station() { }

}
