using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class GroupFunction : BaseAuditableEntity
{
	public int GroupId { get; set; }

	public int FunctionId { get; set; }
	[JsonIgnore]
	public virtual Function Function { get; set; } = null!;

	[JsonIgnore]
	public virtual Group Group { get; set; } = null!;
	public GroupFunction() { }
}
