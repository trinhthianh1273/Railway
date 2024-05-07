using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using BE.Application.Common.Mappings.RouteMapping;
using BE.Application.Interfaces.Persistences;
using Microsoft.Extensions.Configuration;

namespace BE.Application.Extensions;

public static class IServiceCollectionExtensions
{
	public static void AddApplicationLayer(this IServiceCollection service)
	{
		service.AddAutoMapper(Assembly.GetExecutingAssembly());
		service.AddAutoMapper(typeof(RouteAutoMapperProfile));
		service.AddAutoMapper(typeof(UserAutoMapperProfile));

		service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
