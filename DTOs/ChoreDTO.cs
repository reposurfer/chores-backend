using System.ComponentModel.DataAnnotations;
using chores_backend.Models;

namespace chores_backend.DTOs;

public class CreateChoreDTO
{
    [Required]
    [StringLength(maximumLength: 50, ErrorMessage = "Title is too long.")]
    public string Title { get; set; }
    
    [Required]
    [StringLength(maximumLength: 200, ErrorMessage = "Description is too long.")]
    public string Description { get; set; }
    
    [Required]
    public UserDTO AssigneeId { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [Required]
    public Status Status { get; set; }
    
    [Required]
    public int HouseholdId { get; set; }
}

public class ChoreDTO : CreateChoreDTO
{
    public int Id { get; set; }
}