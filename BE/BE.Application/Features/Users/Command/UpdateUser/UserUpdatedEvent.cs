using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Command.UpdateUser;

public class UserUpdatedEvent : BaseEvent
{
	public User User { get; set; }

	public UserUpdatedEvent(User user)
	{
		User = user;
	}
}
