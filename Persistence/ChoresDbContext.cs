using chores_backend.Models;
using chores_backend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace chores_backend.Persistence;

public class ChoresDbContext : DbContext
{
    public DbSet<Chore> Chores { get; set; } = null!;
    
    public ChoresDbContext(DbContextOptions<ChoresDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ChoreEntityTypeConfiguration());
    }
}