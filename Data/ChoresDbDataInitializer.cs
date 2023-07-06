using chores_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace chores_backend.Data;

public class ChoresDbDataInitializer
{
    private readonly ChoresDbContext _dbContext;

    public ChoresDbDataInitializer(ChoresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedDataAync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        if (await _dbContext.Database.EnsureCreatedAsync())
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new() { Name = "Master", NormalizedName = "MASTER" }
            };

            List<Chore> chores = new ()
            {
                new Chore() { Title = "Do the dishes", Description = "I want you to do the dishes" },
                new Chore() { Title = "Clean the livingroom", Description = "I want you to clean the living room" },
                new Chore() { Title = "Mow the lawn", Description = "I want you to mow the lawn" },
                new Chore() { Title = "Remove dust in the kitchen", Description = "I want you to remove dust in the kitchen" },
                new Chore() { Title = "Clean the toilet", Description = "I want you to clean the toilet" },
                new Chore() { Title = "Clean your room", Description = "I want you to clean your room" },
                new Chore() { Title = "Clean the bathroom", Description = "I want you to clean the bathroom" },
                new Chore() { Title = "Clean the garage", Description = "I want you to clean the garage" },
            };

            await _dbContext.Roles.AddRangeAsync(roles);
            await _dbContext.Chores.AddRangeAsync(chores);
            await _dbContext.SaveChangesAsync();
        }
    }
}