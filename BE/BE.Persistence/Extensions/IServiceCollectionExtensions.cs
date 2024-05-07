using BE.Application.Interfaces.Repositories;
using BE.Persistence.Interceptors;
using BE.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Extensions;

public static class IServiceCollectionExtensions
{
	public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
	{
		//services.AddMappings();
		services.AddRepositories();

		services.AddScoped<PublishDomainEventsInterceptor>();
		services.AddScoped<IPublisher, Mediator>();

	}

	private static void AddRepositories(this IServiceCollection services)
	{

		services
			.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
			.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
			.AddTransient<IStationRepository, StationRepository>();
		
	}
}
