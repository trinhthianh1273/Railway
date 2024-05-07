using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
	public void Configure(EntityTypeBuilder<Station> builder)
	{
		ConfigureStationTable(builder);
	}

	private static void ConfigureStationTable(EntityTypeBuilder<Station> builder)
	{
		builder.ToTable("Station");

		builder.HasIndex(e => e.StationName, "IX_Station_1").IsUnique();

		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("StationID");
		builder.HasKey(e => e.Id);

		builder.Property(e => e.StationName).HasMaxLength(50);
	}
}
