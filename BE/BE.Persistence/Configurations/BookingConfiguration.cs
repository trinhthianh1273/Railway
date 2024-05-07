using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
	public void Configure(EntityTypeBuilder<Booking> builder)
	{
		ConfigureBookingTable(builder);
	}

	private static void ConfigureBookingTable(EntityTypeBuilder<Booking> builder)
	{
		builder.ToTable("Booking").HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("BookingID");

		// builder.Property(e => e.BookingId).HasDefaultValueSql("(newid())").HasColumnName("BookingID");
		builder.Property(e => e.CancellationFee).HasColumnType("decimal(18, 0)");
		builder.Property(e => e.CancellationTime).HasColumnType("datetime");

		builder.Property(e => e.PaymentTerm).HasColumnType("datetime");
		builder.Property(e => e.TotalFare).HasColumnType("decimal(18, 0)");
		builder.Property(e => e.TotalPayment).HasColumnType("decimal(18, 0)");


		builder
			.Property(e => e.PassengerId)
			.HasColumnName("PassengerId");
		builder
			.HasOne(d => d.Passenger)
			.WithMany(p => p.Bookings)
			.HasForeignKey(d => d.PassengerId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Booking_Passenger");

		builder
			.Property(e => e.PaymentMethodId)
			.HasColumnName("PaymentMethodID");

		builder
			.HasOne(d => d.PaymentMethod)
			.WithMany(p => p.Bookings)
			.HasForeignKey(d => d.PaymentMethodId)
			.HasConstraintName("FK_Booking_PaymentMethod");
	}
}
