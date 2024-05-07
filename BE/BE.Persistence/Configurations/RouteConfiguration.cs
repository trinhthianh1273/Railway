using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
	public void Configure(EntityTypeBuilder<Route> builder)
	{
		ConfigureRouteTable(builder);
	}
	private static void ConfigureRouteTable(EntityTypeBuilder<Route> builder)
	{
		builder.ToTable("Route");

		builder.HasIndex(e => e.RouteName, "IX_Route_1").IsUnique();

		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("RouteID");
		builder.HasKey(e => e.Id);

		builder.Property(e => e.RouteFare).HasColumnType("decimal(18, 0)");
		builder.Property(e => e.RouteName).HasMaxLength(50);

		builder
			.Property(e => e.DepartureStation)
			.HasColumnName("DepartureStation");
		builder
			.HasOne(d => d.DepartureStationNavigation)
			.WithMany(p => p.RouteDepartureStationNavigations)
			.HasForeignKey(d => d.DepartureStation)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Route_Station");

		builder
			.Property(e => e.DestinationStation)
			.HasColumnName("DestinationStation");
		builder
			.HasOne(d => d.DestinationStationNavigation)
			.WithMany(p => p.RouteDestinationStationNavigations)
			.HasForeignKey(d => d.DestinationStation)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Route_Destination_Station");
	}
}
