using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class GroupFunctionConfiguration : IEntityTypeConfiguration<GroupFunction>
{
	public void Configure(EntityTypeBuilder<GroupFunction> builder)
	{
		ConfigureGroupFunctionTable(builder);
	}
	private static void ConfigureGroupFunctionTable(EntityTypeBuilder<GroupFunction> builder)
	{
		builder.HasKey(nameof(GroupFunction.GroupId), nameof(GroupFunction.FunctionId));

		builder.ToTable("GroupFunction");

		builder
			.Property(e => e.GroupId)
			.HasColumnName("GroupID");
		builder
			.Property(e => e.FunctionId)
			.HasColumnName("FunctionID");


		builder
			.HasOne(d => d.Function)
			.WithMany(p => p.GroupFunctions)
			.HasForeignKey(d => d.FunctionId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_GroupFunction_Function");

		builder
			.HasOne(d => d.Group)
			.WithMany(p => p.GroupFunctions)
			.HasForeignKey(d => d.GroupId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_GroupFunction_Group");
	}
}
