using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
	public void Configure(EntityTypeBuilder<Seat> builder)
	{
		ConfigureSeatTable(builder);
	}

	private static void ConfigureSeatTable(EntityTypeBuilder<Seat> builder)
	{
		builder.ToTable("Seat");

		builder.HasIndex(e => e.SeatNo, "IX_Seat_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("SeatID");

		builder
			.Property(e => e.CoachId)
			.HasColumnName("CoachID");

		builder.Property(e => e.SeatNo).HasMaxLength(50);
		builder
			.Property(e => e.SeatTypeId)
			.HasColumnName("SeatTypeID");

		builder
			.HasOne(d => d.Coach)
			.WithMany(p => p.Seats)
			.HasForeignKey(d => d.CoachId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Seat_Coach");

		builder
			.HasOne(d => d.SeatType)
			.WithMany(p => p.Seats)
			.HasForeignKey(d => d.SeatTypeId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Seat_SeatType");
	}
}
