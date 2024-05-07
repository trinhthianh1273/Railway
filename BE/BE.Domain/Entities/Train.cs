using BE.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Domain.Entities;

public class Train : BaseAuditableEntity
{
	public string TrainName { get; set; }
	[JsonIgnore]
	public ICollection<Coach> Coaches { get; set; } = new List<Coach>();

	[JsonIgnore]
	public ICollection<Trip> Trips { get; set; } = new List<Trip>();
	public Train () { }
}
