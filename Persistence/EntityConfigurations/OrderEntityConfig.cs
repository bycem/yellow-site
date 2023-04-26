using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderEntityConfig : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.ToTable("Orders", schema: "accounting");

        builder.HasOne(x => x.Seller).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Buyer).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.VehicleListing).WithMany();

        builder.HasMany("_payments").WithOne("Order").HasForeignKey("OrderId");

        builder.Property(x => x.SellingPrice).HasColumnType("money");

    }
}