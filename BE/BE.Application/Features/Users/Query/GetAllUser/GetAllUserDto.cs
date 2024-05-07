using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Query.GetAllUser;

public class GetAllUserDto
{
	public string UserName { get; set; }

	public string Email { get; set; }

	public string Password { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }
	public string? Token { get; set; }

	public GetAllUserDto()
	{
	}

	public GetAllUserDto(string userName, string email, string password, string firstName, string lastName, string? token)
	{
		UserName = userName;
		Email = email;
		Password = password;
		FirstName = firstName;
		LastName = lastName;
		Token = token;
	}
}
