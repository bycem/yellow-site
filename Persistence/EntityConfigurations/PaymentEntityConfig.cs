using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PaymentEntityConfig : BaseEntityConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.ToTable("Payments", schema: "accounting");

        builder.HasOne(x => x.Order);

        builder.Property(x => x.Amount).HasColumnType("money");

    }
}