using System.ComponentModel.DataAnnotations;

namespace chores_backend.DTOs;

public class LoginDTO
{
    [System.ComponentModel.DataAnnotations.Required]
    [StringLength(200)]
    public string Username { get; set; }
    
    [System.ComponentModel.DataAnnotations.Required]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d).{5,}$", ErrorMessage = "Password must be at least 5 characters and contain at least one letter and number.")]
    public string Password { get; set; }
}