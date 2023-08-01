using chores_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chores_backend.Data.Repositories;

public class ChoresRepository : IChoresRepository
{
    private readonly ChoresDbContext _context;
    private readonly DbSet<Chore> _chores;

    public ChoresRepository(ChoresDbContext context)
    {
        _context = context;
        _chores = context.Chores;
    }
    
    public IEnumerable<Chore> GetAll()
    {
        return _chores.ToList();
    }

    public void Add(Chore chore)
    {
        _chores.Add(chore);
    }

    public void Update(Chore chore)
    {
        _chores.Update(chore);
    }

    public void Delete(Chore chore)
    {
        _chores.Remove(chore);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}