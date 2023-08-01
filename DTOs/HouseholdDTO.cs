namespace chores_backend.DTOs;

public class CreateHouseholdDTO
{
    public string Name { get; set; }
    
    public UserDTO Owner { get; set; }
}

public class HouseholdDTO : CreateHouseholdDTO
{
    public int Id { get; set; }
}