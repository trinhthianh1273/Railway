using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class User : BaseAuditableEntity
{
	public string UserName { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string Password { get; set; } = null!;

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string? Token { get; set; }
	public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
	public User() { }
}
