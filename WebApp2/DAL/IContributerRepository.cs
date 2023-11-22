using WebApp2.Models;

namespace WebApp2.DAL;

public interface IContributerRepository
{
    Task<IEnumerable<Contributer>?> GetAll();
    Task<Contributer?> GetContributerById(int id); 
    Task<bool> Create(Contributer contributer);
    Task<bool> Update(Contributer contributer);
    Task<bool> Delete(int id);


}

