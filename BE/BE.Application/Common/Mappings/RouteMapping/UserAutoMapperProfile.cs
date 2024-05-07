using AutoMapper;
using BE.Application.Features.Users.Query.GetAllUser;
using BE.Application.Features.Users.Query.GetUserById;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Mappings.RouteMapping;

public class UserAutoMapperProfile : Profile
{
	public UserAutoMapperProfile()
	{
		CreateMap<User, GetAllUserDto>();
		CreateMap<User, GetUserByIdDto>();
	}
	
}
