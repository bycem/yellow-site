using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CustomerEntityConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", schema: "accounts");

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.FullName)
                .IsRequired();

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
