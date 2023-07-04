namespace chores_backend.Models;

public interface IChoresRepository
{
    IEnumerable<Chore> GetAll();
    void Add(Chore chore);
    void Update(Chore chore);
    void Delete(Chore chore);
    void SaveChanges();
}