using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
    }
}