using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Booking : BaseAuditableEntity
{
	public int PassengerId { get; set; }
	public decimal TotalFare { get; set; }

	public decimal TotalPayment { get; set; }

	public string Status { get; set; }

	public DateTime PaymentTerm { get; set; }

	public int? PaymentMethodId { get; set; } = null!;
	public DateTime? CancellationTime { get; set; } = null!;

	public decimal? CancellationFee { get; set; } = null!;

	public string? CancellationReason { get; set; } = null!;

	public DateTime BookingTime { get; set; }

	public int? UserId { get; set; }

	public decimal? PaidAmount { get; set; } = null!;

	public DateTime? PaidTime { get; set; } = null!;

	public decimal? RefundAmount { get; set; } = null!;

	public DateTime? RefundTime { get; set; } = null!;
	public virtual ICollection<BookingStatus> BookingStatuses { get; set; } = new List<BookingStatus>();

	public virtual ICollection<BookingTicket> BookingTickets { get; set; } = new List<BookingTicket>();

	public virtual Passenger Passenger { get; set; }

	public virtual PaymentMethod PaymentMethod { get; set; }

	public Booking()
	{
	}
}
