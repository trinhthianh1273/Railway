using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
	public void Configure(EntityTypeBuilder<Trip> builder)
	{
		ConfigureTripTable(builder);
	}
	private static void ConfigureTripTable(EntityTypeBuilder<Trip> builder)
	{
		builder.ToTable("Trip").HasKey(e => e.Id);

		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("TripID");
		builder.Property(e => e.ArriveTime).HasColumnType("datetime");
		builder.Property(e => e.DepartureTime).HasColumnType("datetime");
		builder
			.Property(e => e.RouteId)
			.HasColumnName("RouteID");
		builder
			.Property(e => e.TrainId)
			.HasColumnName("TrainID");

		builder
			.HasOne(d => d.Route)
			.WithMany(p => p.Trips)
			.HasForeignKey(d => d.RouteId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Trip_Route");

		builder
			.HasOne(d => d.Train)
			.WithMany(p => p.Trips)
			.HasForeignKey(d => d.TrainId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Trip_Train");
	}
}
