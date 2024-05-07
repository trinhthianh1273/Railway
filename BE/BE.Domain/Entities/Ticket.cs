using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Ticket : BaseAuditableEntity
{
	public int TripId { get; set; }

	public int SeatId { get; set; }

	public decimal? Fare { get; set; }

	public string Status { get; set; }
	[JsonIgnore]
	public ICollection<BookingTicket> BookingTickets { get; set; } = new List<BookingTicket>();

	[JsonIgnore]
	public Seat Seat { get; set; } = null!;

	public Trip Trip { get; set; }
	public Ticket() { }
}
