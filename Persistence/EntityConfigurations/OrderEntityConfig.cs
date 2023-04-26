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

        builder.HasOne(x => x.Seller).WithOne();
        builder.HasOne(x => x.Buyer).WithOne();
        builder.HasOne(x => x.VehicleListing).WithOne();

        builder.HasMany(x=>x.Payments).WithOne(x=>x.Order);

        builder.Property(x => x.SellingPrice).HasColumnType("money");

        builder.HasIndex(x => x.SellerId);
        builder.HasIndex(x => x.BuyerId);
    }
}