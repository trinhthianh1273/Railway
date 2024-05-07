using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
	public void Configure(EntityTypeBuilder<Coach> builder)
	{
		ConfigureCoachTable(builder);
	}

	private static void ConfigureCoachTable(EntityTypeBuilder<Coach> builder)
	{
		builder.ToTable("Coach");

		builder.HasIndex(e => e.CoachNo, "IX_Coach").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("CoachID");

		builder.Property(e => e.CoachNo).HasMaxLength(50);

		builder
			.HasOne(d => d.Train)
			.WithMany(p => p.Coaches)
			.HasForeignKey(d => d.TrainId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Coach_Train");
	}
}
