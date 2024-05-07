using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Group : BaseAuditableEntity
{
	public string GroupName { get; set; }
	[JsonIgnore]
	public ICollection<GroupFunction> GroupFunctions { get; set; } = new List<GroupFunction>();

	[JsonIgnore]
	public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
	public Group()
	{
	}
}
