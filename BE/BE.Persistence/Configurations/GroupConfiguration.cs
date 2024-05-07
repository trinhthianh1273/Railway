using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
	public void Configure(EntityTypeBuilder<Group> builder)
	{
		ConfigureGroupTable(builder);
	}

	private static void ConfigureGroupTable(EntityTypeBuilder<Group> builder)
	{
		builder.ToTable("Group");

		builder.HasIndex(e => e.GroupName, "IX_Group_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("GroupID");

	}
}
