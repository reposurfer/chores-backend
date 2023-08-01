namespace chores_backend.Models;

// This is a data class.

public class Chore
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public User Assignee { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public Status Status { get; set; }
    
    public Household Household { get; set; }
}

public enum Status
{
    Pending,
    InProgress,
    Completed,
    Overdue
}