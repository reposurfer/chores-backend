using chores_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace chores_backend.Data;

public class ChoresDbDataInitializer
{
    private readonly ChoresDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public ChoresDbDataInitializer(ChoresDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task SeedDataAync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        if (await _dbContext.Database.EnsureCreatedAsync())
        {
            //Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new() { Name = "Master", NormalizedName = "MASTER" }
            };
            
            await _dbContext.Roles.AddRangeAsync(roles);

            //Users
            ICollection<string> userRoles = new List<string>()
            {
                "Master"
            };

            User user = new User() { FirstName = "Stef", LastName = "Boerjan", UserName = "stefboerjan", Description = "", Picture = ""};


            await _userManager.CreateAsync(user, "Password1");
            await _userManager.AddToRolesAsync(user, userRoles);

            //Households
            List<Household> households = new()
            {
                new Household() { Name = "Family Boerjan", Owner = user }
            };
            
            //Chores
            List<Chore> chores = new ()
            {
                new Chore() { Title = "Do the dishes", Description = "I want you to do the dishes", Status = Status.Pending, Assignee = user, Household = households.First()},
                new Chore() { Title = "Clean the livingroom", Description = "I want you to clean the living room", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Mow the lawn", Description = "I want you to mow the lawn", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Remove dust in the kitchen", Description = "I want you to remove dust in the kitchen", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Clean the toilet", Description = "I want you to clean the toilet", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Clean your room", Description = "I want you to clean your room", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Clean the bathroom", Description = "I want you to clean the bathroom", Status = Status.Pending, Assignee = user, Household = households.First() },
                new Chore() { Title = "Clean the garage", Description = "I want you to clean the garage", Status = Status.Pending, Assignee = user, Household = households.First() },
            };
            
            await _dbContext.Chores.AddRangeAsync(chores);

            await _dbContext.Households.AddRangeAsync(households);
            
            await _dbContext.SaveChangesAsync();
        }
    }
}