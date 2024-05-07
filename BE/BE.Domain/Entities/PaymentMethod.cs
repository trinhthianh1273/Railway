using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class PaymentMethod : BaseAuditableEntity
{
	public string PaymentMethodName { get; set; }
	[JsonIgnore]
	public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	public PaymentMethod()
	{
	}
}
