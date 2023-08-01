using chores_backend.Models;

namespace chores_backend.Data.Repositories;

public interface IHouseholdsRepository
{
    IEnumerable<Household> GetAll();
    void Add(Household household);
    void Update(Household household);
    void Delete(Household household);
    void SaveChanges();
}