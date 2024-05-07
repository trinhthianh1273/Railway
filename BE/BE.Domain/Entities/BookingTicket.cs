using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class BookingTicket : BaseAuditableEntity
{
	public BookingTicket()
	{
	}

	public int BookingId { get; set; }

	public int TicketId { get; set; }
	[JsonIgnore]
	public Booking Booking { get; set; } = null!;
	[JsonIgnore]
	public Ticket Ticket { get; set; } = null!;


}
