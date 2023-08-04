using chores_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chores_backend.Data.Configurations;

public class ChoreEntityTypeConfiguration : IEntityTypeConfiguration<Chore>
{
    public void Configure(EntityTypeBuilder<Chore> builder)
    {
        builder.ToTable("Chores");
        builder.Property(c => c.Title).HasColumnName("Title").IsRequired();
        builder.Property(c => c.Description).HasColumnName("Description").IsRequired();
        builder.Property(c => c.DueDate).HasColumnName("DueDate").IsRequired();
        builder.Property(c => c.Status).HasColumnName("Status").IsRequired();

        builder.HasOne(c => c.Assignee).WithMany();
        builder.HasOne(c => c.Household).WithMany();

    }
}