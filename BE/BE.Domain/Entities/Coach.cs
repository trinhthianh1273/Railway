using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Coach : BaseAuditableEntity
{
	public Coach()
	{
	}

	public string CoachNo { get; set; } = null!;

	public int TrainId { get; set; }
	[JsonIgnore]
	public ICollection<Seat> Seats { get; set; } = new List<Seat>();
	[JsonIgnore]
	public Train Train { get; set; } = null!;

}
