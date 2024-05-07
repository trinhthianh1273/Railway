using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Passenger : BaseAuditableEntity
{
	public int Id { get; set; }

	public string FullName { get; set; } = null!;

	public DateTime Dob { get; set; }

	public string Genger { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string? PhoneNo { get; set; }

	public string Password { get; set; } = null!;

	public string Address { get; set; } = null!;

	public string? Image { get; set; } = null!;

	public string? Token { get; set; } = null!;

	[JsonIgnore]
	public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

	public Passenger() { }
}
