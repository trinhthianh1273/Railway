using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class TrainConfiguration : IEntityTypeConfiguration<Train>
{
	public void Configure(EntityTypeBuilder<Train> builder)
	{
		ConfigureTrainTable(builder);
	}
	private static void ConfigureTrainTable(EntityTypeBuilder<Train> builder)
	{
		builder.ToTable("Train");

		builder.HasIndex(e => e.TrainName, "IX_Train_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("TrainID");
		builder.Property(e => e.TrainName).HasMaxLength(50);
	}
}
