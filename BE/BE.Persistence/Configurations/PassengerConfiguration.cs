using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
	public void Configure(EntityTypeBuilder<Passenger> builder)
	{
		ConfigurePassengerTable(builder);
	}

	private static void ConfigurePassengerTable(EntityTypeBuilder<Passenger> builder)
	{
		builder.ToTable("Passenger").HasKey(d => d.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("PassengerID");

		builder.HasIndex(e => new { e.Email, e.PhoneNo }, "IX_Passenger_1").IsUnique();

		builder.Property(e => e.Address).HasMaxLength(150);

		builder.Property(e => e.Dob).HasColumnType("date");
		builder.Property(e => e.Email).HasMaxLength(50);
		builder.Property(e => e.FullName).HasMaxLength(50);
		builder.Property(e => e.Genger).HasMaxLength(50);
		builder.Property(e => e.Image).HasMaxLength(50);
		builder.Property(e => e.Password).HasMaxLength(100);
		builder.Property(e => e.PhoneNo).HasMaxLength(10);
		builder.Property(e => e.Token).HasColumnName("token");
	}
}
