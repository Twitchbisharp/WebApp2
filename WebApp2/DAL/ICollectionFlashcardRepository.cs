using WebApp2.Models;

namespace WebApp2.DAL;

public interface ICollectionFlashcardRepository
{
    Task<IEnumerable<CollectionFlashcard>?> GetAll();
    Task<CollectionFlashcard?> GetCollectionFlashcardById(int id); 
    Task<bool> Create(CollectionFlashcard collectionFlashcard);
    Task<bool> Update(CollectionFlashcard collectionFlashcard);
    Task<bool> Delete(int id);


}

