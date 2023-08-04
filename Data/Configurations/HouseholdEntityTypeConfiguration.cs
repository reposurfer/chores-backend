using chores_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chores_backend.Data.Configurations;

public class HouseholdEntityTypeConfiguration : IEntityTypeConfiguration<Household>
{
    public void Configure(EntityTypeBuilder<Household> builder)
    {
        builder.ToTable("Households");
        builder.Property(h => h.Name).HasColumnName("Name").IsRequired();

        builder.HasOne(h => h.Owner).WithMany();
    }
}