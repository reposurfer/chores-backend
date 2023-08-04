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

    public async Task SeedDataAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        if (await _dbContext.Database.EnsureCreatedAsync())
        {
            //Roles
            var roles = new List<IdentityRole>
            {
                new() { Name = "Master", NormalizedName = "MASTER" }
            };
            
            await _dbContext.Roles.AddRangeAsync(roles);

            //Users
            var userRoles = new List<string>()
            {
                "Master"
            };

            var user = new User { FirstName = "Stef", LastName = "Boerjan", UserName = "stefboerjan", Description = "", Picture = ""};


            await _userManager.CreateAsync(user, "Password1");
            await _userManager.AddToRolesAsync(user, userRoles);

            //Households
            var households = new List<Household>
            {
                new()
                {
                    Name = "Family Boerjan", 
                    Owner = user
                }
            };
            
            //Chores
            var chores = new List<Chore> 
            {
                new() 
                { 
                    Title = "Do the dishes", 
                    Description = "I want you to do the dishes", 
                    DueDate = DateTime.UtcNow.AddMonths(3), 
                    Status = Status.Pending, 
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Clean the livingroom", 
                    Description = "I want you to clean the living room", 
                    DueDate = DateTime.UtcNow.AddMonths(3), 
                    Status = Status.Pending,
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Mow the lawn", 
                    Description = "I want you to mow the lawn", 
                    DueDate = DateTime.UtcNow.AddMonths(3),
                    Status = Status.Pending, 
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Remove dust in the kitchen", 
                    Description = "I want you to remove dust in the kitchen", 
                    DueDate = DateTime.UtcNow.AddMonths(3), 
                    Status = Status.Pending, 
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Clean the toilet", 
                    Description = "I want you to clean the toilet", 
                    DueDate = DateTime.UtcNow.AddMonths(3),
                    Status = Status.Pending,
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Clean your room", 
                    Description = "I want you to clean your room", 
                    DueDate = DateTime.UtcNow.AddMonths(3),
                    Status = Status.Pending,
                    Assignee = user,
                    Household = households.First()
                },
                new()
                {
                    Title = "Clean the bathroom", 
                    Description = "I want you to clean the bathroom", 
                    DueDate = DateTime.UtcNow.AddMonths(3), 
                    Status = Status.Pending, 
                    Assignee = user, 
                    Household = households.First()
                },
                new()
                {
                    Title = "Clean the garage", 
                    Description = "I want you to clean the garage", 
                    DueDate = DateTime.UtcNow.AddMonths(3), 
                    Status = Status.Pending,
                    Assignee = user, 
                    Household = households.First()
                },
            };
            
            await _dbContext.Chores.AddRangeAsync(chores);

            await _dbContext.Households.AddRangeAsync(households);
            
            await _dbContext.SaveChangesAsync();
        }
    }
}