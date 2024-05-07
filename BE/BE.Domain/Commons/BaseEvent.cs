﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Commons;

public abstract class BaseEvent : INotification
{
	public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
