using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class SeatType : BaseAuditableEntity
{
	public string SeatTypeName { get; set; }

	public double RaitoFare { get; set; }
	[JsonIgnore]
	public ICollection<Seat> Seats { get; set; } = new List<Seat>();
	public SeatType() { }
}
