using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		ConfigureTicketTable(builder);
	}
	private static void ConfigureTicketTable(EntityTypeBuilder<Ticket> builder)
	{
		builder.ToTable("Ticket");

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("TicketID");
		builder
			.Property(e => e.TripId)
			.HasColumnName("TripID");

		builder
			.HasOne(d => d.Trip)
			.WithMany(p => p.Tickets)
			.HasForeignKey(d => d.TripId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Ticket_Trip");

		builder
			.Property(e => e.SeatId)
			.HasColumnName("SeatID");
		builder
			.HasOne(d => d.Seat)
			.WithMany(p => p.Tickets)
			.HasForeignKey(d => d.SeatId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Ticket_Seat");

	}
}
