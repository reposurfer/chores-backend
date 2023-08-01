using chores_backend.Data.Configurations;
using chores_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace chores_backend.Data;

public class ChoresDbContext : IdentityDbContext<User>
{
    public DbSet<Chore> Chores { get; set; } = null!;

    public DbSet<Household> Households { get; set; } = null!;

    public ChoresDbContext(DbContextOptions<ChoresDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ChoreEntityTypeConfiguration());
    }
}