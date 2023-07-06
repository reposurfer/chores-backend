using System.ComponentModel.DataAnnotations;

namespace chores_backend.DTOs;

public class LoginDTO
{
    [Required]
    [StringLength(200)]
    public string Username { get; set; }
    
    [Required]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d).{5,}$", ErrorMessage = "Password must be at least 5 characters and contain at least one letter and number.")]
    public string Password { get; set; }
}

public class RegisterDTO : LoginDTO
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public ICollection<string> Roles { get; set; }
}