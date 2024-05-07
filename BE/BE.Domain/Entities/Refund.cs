using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Refund : BaseAuditableEntity
{
	public int BookingId { get; set; }

	public decimal RefundAmount { get; set; }

	public int Status { get; set; }

	public DateTime? RefundTime { get; set; }
	public Booking Booking { get; set; } = null!;
	public Refund() { }
}
