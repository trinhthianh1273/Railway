using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
{
	public void Configure(EntityTypeBuilder<SeatType> builder)
	{
		ConfigureSeatTypeTable(builder);
	}

	private static void ConfigureSeatTypeTable(EntityTypeBuilder<SeatType> builder)
	{
		builder.ToTable("SeatType");

		builder.HasIndex(e => e.SeatTypeName, "IX_SeatType_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("SeatTypeID");
		builder.Property(e => e.SeatTypeName).HasMaxLength(50);
	}
}
