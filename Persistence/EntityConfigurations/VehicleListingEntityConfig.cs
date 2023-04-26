using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VehicleListingEntityConfig : BaseEntityConfiguration<VehicleListing>
{
    public override void Configure(EntityTypeBuilder<VehicleListing> builder)
    {
        base.Configure(builder);

        builder.ToTable("Listings", schema: "sale");

        builder.HasOne(x => x.Customer)
            .WithMany().IsRequired();

        builder.Property(x => x.SellingPrice)
            .HasColumnType("money")
            .IsRequired();

        builder.Property(x => x.MileAge)
            .IsRequired();

        builder.OwnsOne(x => x.VehicleValueObject,
            navigationBuilder =>
            {
                navigationBuilder.Property(x => x.Brand).HasColumnName("Brand").IsRequired().HasMaxLength(64);
                navigationBuilder.Property(x => x.Model).HasColumnName("Model").IsRequired().HasMaxLength(256);
                navigationBuilder.Property(x => x.ModelYear).HasColumnName("ModelYear").IsRequired();
            });



    }
}