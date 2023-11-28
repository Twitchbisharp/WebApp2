using WebApp2.Models;

namespace WebApp2.DAL;

public interface ICollectionRepository
{
    Task<IEnumerable<Collection>?> GetAll();
    Task<Collection?> GetCollectionById(int id); 
    Task<bool> Create(Collection collection);
    Task<bool> Update(Collection collection);
    Task<bool> Delete(int id);


}

