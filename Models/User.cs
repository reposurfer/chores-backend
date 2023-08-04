using Microsoft.AspNetCore.Identity;

namespace chores_backend.Models;

// This is a data class
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Description { get; set; }
    
    public string Picture { get; set; }
}