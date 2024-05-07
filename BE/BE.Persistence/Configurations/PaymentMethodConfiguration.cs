using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
	public void Configure(EntityTypeBuilder<PaymentMethod> builder)
	{
		ConfigurePaymentMethodTable(builder);
	}

	private static void ConfigurePaymentMethodTable(EntityTypeBuilder<PaymentMethod> builder)
	{
		builder.ToTable("PaymentMethod");

		builder.HasIndex(e => e.PaymentMethodName, "IX_PaymentMethod_1").IsUnique();

		builder.HasKey(e => e.Id);
		builder
			.Property(e => e.Id)
			.UseIdentityColumn()
			.HasColumnName("PaymentMethodID");

		builder.Property(e => e.PaymentMethodName).HasMaxLength(50);
	}
}
