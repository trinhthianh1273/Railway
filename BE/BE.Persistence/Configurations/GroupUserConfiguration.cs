using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
	public void Configure(EntityTypeBuilder<GroupUser> builder)
	{
		ConfigureGroupUserTable(builder);
	}
	private static void ConfigureGroupUserTable(EntityTypeBuilder<GroupUser> builder)
	{
		builder.HasKey(nameof(GroupUser.GroupId), nameof(GroupUser.UserId));
		builder.ToTable("GroupUser");

		builder
			.Property(e => e.GroupId)
			.HasColumnName("GroupID");
		builder
			.Property(e => e.UserId)
			.HasColumnName("UserID");
		builder
			.HasOne(d => d.Group)
			.WithMany(p => p.GroupUsers)
			.HasForeignKey(d => d.GroupId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_GroupUser_Group");

		builder
			.HasOne(d => d.User)
			.WithMany(p => p.GroupUsers)
			.HasForeignKey(d => d.UserId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_GroupUser_User");
	}
}
