using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		ConfigureUserTable(builder);
	}
	private static void ConfigureUserTable(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("User");

		builder.HasIndex(e => new { e.Email, e.UserName }, "IX_User_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("UserID");
		builder.Property(e => e.Email).HasMaxLength(50);
		builder.Property(e => e.FirstName).HasMaxLength(50);
		builder.Property(e => e.LastName).HasMaxLength(50);
		builder.Property(e => e.Password).HasMaxLength(50);
		builder.Property(e => e.Token).HasColumnName("token");
		builder.Property(e => e.UserName).HasMaxLength(50);
	}
}
