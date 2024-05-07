using BE.Domain.Commons.Interfaces;
using BE.Domain.Commons;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Application.Interfaces.Persistences;
using BE.Infranstructure.Authentication;
using Microsoft.Extensions.Configuration;
using BE.Application.Interfaces.Repositories;

namespace BE.Infranstructure.Extensions;

public static class IServiceCollectionExtensions
{
	public static void AddInfrastructureLayer(this IServiceCollection services, ConfigurationManager configuration)
	{
		services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

		services
			.AddTransient<IDateTimeProvider, DateTimeProvider>()
			.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
			.AddTransient<IPasswordHasing, PasswordHassing>()
			.AddTransient<IMediator, Mediator>()
			.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
		//.AddTransient<IDateTimeService, DateTimeService>()
		//.AddTransient<IEmailService, EmailService>();
	}
}
