using Domain.Models;
using Domain.ValueObjects;
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

        builder.Property(x => x.Plate)
            .HasMaxLength(8)
            .IsRequired();

        builder.HasIndex(x => x.Plate);


        builder.OwnsOne(x => x.VehicleValueObject,
            navigationBuilder =>
            {
                navigationBuilder.Property(x => x.Brand).HasColumnName(nameof(VehicleValueObject.Brand)).IsRequired().HasMaxLength(64);
                navigationBuilder.Property(x => x.Model).HasColumnName(nameof(VehicleValueObject.Model)).IsRequired().HasMaxLength(256);
                navigationBuilder.Property(x => x.ModelYear).HasColumnName(nameof(VehicleValueObject.ModelYear)).IsRequired();

                navigationBuilder.HasIndex(x => x.Brand)
                    .IncludeProperties(nameof(VehicleValueObject.Model), nameof(VehicleValueObject.ModelYear));
            });

        builder.Navigation(x => x.Customer).AutoInclude();

    }
}