using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class BookingStatus : BaseAuditableEntity
{

	public int BookingId { get; set; }

	public string Status { get; set; }

	public DateTime StatusTime { get; set; }
	[JsonIgnore]
	public virtual Booking Booking { get; set; }

	public BookingStatus()
	{
	}
}
