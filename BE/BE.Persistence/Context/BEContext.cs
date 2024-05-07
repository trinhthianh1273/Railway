using BE.Domain.Commons;
using BE.Domain.Commons.Interfaces;
using BE.Domain.Entities;
using BE.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Context;

public class BEContext : DbContext
{
	private readonly IConfiguration _configuration;
	private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
	private readonly IDomainEventDispatcher _dispatcher;

	public BEContext(
		DbContextOptions options,
		IConfiguration configuration, 
		PublishDomainEventsInterceptor publishDomainEventsInterceptor,
		IDomainEventDispatcher dispatcher)
		: base(options)
	{
		_configuration = configuration;
		_publishDomainEventsInterceptor = publishDomainEventsInterceptor;
		_dispatcher = dispatcher;
	}

	public BEContext() { }

	public DbSet<Booking> Bookings { get; set; } = null!;
	public DbSet<BookingTicket> BookingTickets { get; set; } = null!;
	public DbSet<Coach> Coaches { get; set; } = null!;
	public DbSet<Function> Functions { get; set; } = null!;
	public DbSet<Group> Groups { get; set; } = null!;
	public DbSet<GroupFunction> GroupFunctions { get; set; } = null!;
	public DbSet<GroupUser> GroupUsers { get; set; } = null!;
	public DbSet<Passenger> Passengers { get; set; } = null!;
	public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
	public DbSet<Route> Routes { get; set; } = null!;
	public DbSet<Seat> Seat { get; set; } = null!;
	public DbSet<SeatType> SeatTypes { get; set; } = null!;
	public DbSet<Station> Stations { get; set; } = null!;
	public DbSet<Train> Trains { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	public DbSet<Trip> Trips { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Ignore<List<BaseEvent>>()
			.ApplyConfigurationsFromAssembly(typeof(BEContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbContext"));
		optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
		base.OnConfiguring(optionsBuilder);
	}

}
