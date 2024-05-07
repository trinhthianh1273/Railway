using BE.Domain.Commons;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Command.DeleteUser;

public class UserDeletedEvent : BaseEvent
{
	public User User { get; }

	public UserDeletedEvent(User user)
	{
		User = user;
	}
}
