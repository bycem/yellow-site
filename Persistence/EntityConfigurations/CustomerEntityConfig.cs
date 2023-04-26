using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerEntityConfig : BaseEntityConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("Customers", schema: "accounts");

        builder.Property(x => x.Email)
            .IsRequired();

        builder.Property(x => x.FullName)
            .IsRequired();

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.Username).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.UserId).HasMaxLength(128).IsRequired();

        builder.HasIndex(x => x.UserId).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}