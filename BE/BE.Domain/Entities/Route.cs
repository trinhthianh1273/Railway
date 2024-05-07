using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Route : BaseAuditableEntity
{
	public string RouteName { get; set; }
	public int DepartureStation { get; set; }
	public int DestinationStation { get; set; }
	public decimal RouteFare { get; set; }

	[JsonIgnore]
	public Station DepartureStationNavigation { get; set; } = null!;
	[JsonIgnore]
	public Station DestinationStationNavigation { get; set; } = null!;

	[JsonIgnore]
	public ICollection<Trip> Trips { get; set; } = new List<Trip>();
	public Route()
	{
	}
}
