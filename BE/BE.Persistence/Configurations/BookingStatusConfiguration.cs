using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class BookingStatusConfiguration : IEntityTypeConfiguration<BookingStatus>
{
	public void Configure(EntityTypeBuilder<BookingStatus> builder)
	{
		ConfigureBookingStatusTable(builder);
	}
	private static void ConfigureBookingStatusTable(EntityTypeBuilder<BookingStatus> builder)
	{
		builder.ToTable("BookingStatus");

		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("BookingStatusID");
		builder
			.Property(e => e.BookingId)
			.HasColumnName("BookingID");

		builder.Property(e => e.Status).IsRequired().HasMaxLength(50).IsFixedLength();
		builder
			.Property(e => e.StatusTime)
			.HasDefaultValueSql("(getdate())")
			.HasColumnType("datetime")
			.HasColumnName("statusTime");

		builder
			.HasOne(d => d.Booking)
			.WithMany(p => p.BookingStatuses)
			.HasForeignKey(d => d.BookingId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_BookingStatus_Booking");
	}
}
