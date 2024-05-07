using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Function : BaseAuditableEntity
{
	public Function() { }

	public string FunctionName { get; set; }
	[JsonIgnore]
	public ICollection<GroupFunction> GroupFunctions { get; set; } =
		new List<GroupFunction>();
}
