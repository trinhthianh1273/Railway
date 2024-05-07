using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class BookingTicketConfiguration : IEntityTypeConfiguration<BookingTicket>
{
	public void Configure(EntityTypeBuilder<BookingTicket> builder)
	{
		ConfigureBookingTicketTable(builder);
	}
	private static void ConfigureBookingTicketTable(EntityTypeBuilder<BookingTicket> builder)
	{
		builder.ToTable("BookingTicket");

		builder.HasKey(nameof(BookingTicket.BookingId), nameof(BookingTicket.TicketId));

		builder
			.Property(e => e.BookingId)
			.HasColumnName("BookingID");

		builder
			.Property(e => e.TicketId)
			.HasColumnName("TicketID");

		builder
			.HasOne(d => d.Booking)
			.WithMany(p => p.BookingTickets)
			.HasForeignKey(d => d.BookingId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_BookingTicket_Booking");

		builder
			.HasOne(d => d.Ticket)
			.WithMany(p => p.BookingTickets)
			.HasForeignKey(d => d.TicketId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_BookingTicket_Ticket");
	}
}
