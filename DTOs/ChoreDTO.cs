using System.ComponentModel.DataAnnotations;

namespace chores_backend.DTOs;

public class CreateChoreDTO
{
    [Required]
    [StringLength(maximumLength: 50, ErrorMessage = "Title is too long.")]
    public string Title { get; set; }
    [Required]
    [StringLength(maximumLength: 200, ErrorMessage = "Description is too long.")]
    public string Description { get; set; }
}

public class ChoreDTO : CreateChoreDTO
{
    public int Id { get; set; }
}