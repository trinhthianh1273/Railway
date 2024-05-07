using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class FunctionConfiguration : IEntityTypeConfiguration<Function>
{
	public void Configure(EntityTypeBuilder<Function> builder)
	{
		ConfigureFunctionTable(builder);
	}
	private static void ConfigureFunctionTable(EntityTypeBuilder<Function> builder)
	{
		builder.ToTable("Function");

		builder.HasIndex(e => e.FunctionName, "IX_Function_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("FunctionID");

	}
}
