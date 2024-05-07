﻿using BE.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Commons;

public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
	public int? CreatedBy { get; set; }
	public DateTime? CreatedDate { get; set; }
	public int? UpdatedBy { get; set; }
	public DateTime? UpdatedDate { get; set; }
}
