using chores_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chores_backend.Data.Repositories;

public class HouseholdRespository : IHouseholdsRepository
{
    private readonly ChoresDbContext _context;
    private readonly DbSet<Household> _households;
    
    public HouseholdRespository(ChoresDbContext context)
    {
        _context = context;
        _households = context.Households;
    }
    
    public IEnumerable<Household> GetAll()
    {
        return _households.ToList();
    }

    public void Add(Household household)
    {
        _households.Add(household);
    }

    public void Update(Household household)
    {
        _households.Update(household);
    }

    public void Delete(Household household)
    {
        _households.Remove(household);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}