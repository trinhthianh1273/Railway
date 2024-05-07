using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Seat : BaseAuditableEntity
{
	public int CoachId { get; set; }

	public int SeatTypeId { get; set; }

	public string SeatNo { get; set; }
	[JsonIgnore]
	public Coach Coach { get; set; } = null!;

	[JsonIgnore]
	public SeatType SeatType { get; set; } = null!;

	[JsonIgnore]
	public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
	public Seat() { }
}
