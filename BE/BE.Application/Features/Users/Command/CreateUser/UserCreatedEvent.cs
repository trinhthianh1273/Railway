using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Command.CreateUser;

public class UserCreatedEvent : BaseEvent
{
	public User User { get; }

	public UserCreatedEvent(User user)
	{
		User = user;
	}
}
