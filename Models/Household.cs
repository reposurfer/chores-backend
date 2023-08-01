namespace chores_backend.Models;

public class Household
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public User Owner { get; set; }
}