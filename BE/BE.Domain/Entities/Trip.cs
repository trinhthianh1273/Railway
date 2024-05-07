using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Trip : BaseAuditableEntity
{
	public int TrainId { get; set; }

	public int RouteId { get; set; }

	public DateTime DepartureTime { get; set; }

	public DateTime ArriveTime { get; set; }
	[JsonIgnore]
	public virtual Route Route { get; set; }

	[JsonIgnore]
	public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

	[JsonIgnore]
	public virtual Train Train { get; set; }
	public Trip () { }
}
