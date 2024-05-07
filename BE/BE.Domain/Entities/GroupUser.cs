using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class GroupUser : BaseAuditableEntity
{
	public int GroupId { get; set; }

	public int UserId { get; set; }
	[JsonIgnore]
	public virtual Group Group { get; set; } = null!;

	[JsonIgnore]
	public virtual User User { get; set; } = null!;

	public GroupUser() { }
}
