using System.ComponentModel.DataAnnotations;

namespace chores_backend.DTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "The username field is required.")]
    [StringLength(200)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "The password field is required.")]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d).{5,}$", ErrorMessage = "Password must be at least 5 characters and contain at least one letter and number.")]
    public string Password { get; set; }
}

public class RegisterDTO : LoginDTO
{
    [Required(ErrorMessage = "The firstname field is required.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "The lastname field is required.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "The confirm password field is required.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
    
    [Required]
    public ICollection<string> Roles { get; set; }
}