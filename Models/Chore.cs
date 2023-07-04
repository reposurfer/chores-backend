namespace chores_backend.Models;

// This is a data class.

public class Chore
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}