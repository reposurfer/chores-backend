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
        throw new NotImplementedException();
    }

    public void Update(Chore chore)
    {
        throw new NotImplementedException();
    }

    public void Delete(Chore chore)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}