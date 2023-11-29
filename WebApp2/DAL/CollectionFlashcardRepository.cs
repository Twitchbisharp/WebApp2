using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApp2.DAL;
using WebApp2.Models;

namespace MyShop.DAL;
//namespace WebApp1.DAL;

public class CollectionFlashcardRepository : ICollectionFlashcardRepository
{

    private readonly FlashcardDbContext _db;
    private readonly ILogger<CollectionFlashcardRepository> _logger;

    public CollectionFlashcardRepository(FlashcardDbContext db, ILogger<CollectionFlashcardRepository> logger)
    {
        _db = db;
        _logger = logger;
    }


    //Gets every collection
    public async Task<IEnumerable<CollectionFlashcard>?> GetAll()
    {
       
        try 
        {
            return await _db.CollectionFlashcards.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionFlashcardRepository] CollectionFlashcards ToListAsync() failed when GetAll() was called, error message: {e}", e.Message);
            return null;
        }
    }

    // Gets a single collection by id
    public async Task<CollectionFlashcard?> GetCollectionFlashcardById(int id)
    {
        
        try
        {
            return await _db.CollectionFlashcards.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionFlashcardRepository] collection FindAsync(id) failed when GetCollectionFlashcardById " +
                "for CollectionFlashcardId {CollectionFlashcardId:0000}, error message: {e}", id, e.Message);
            return null;
        }
    }

    // Creates a new collection
    public async Task<bool> Create(CollectionFlashcard collection)
    {
        
        try
        {
            _db.CollectionFlashcards.Add(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionFlashcardRepository] collection creation failed for collection {@collection}, error message: {e}", collection, e.Message);
            return false;
        }
    }

    // Updates an exsisting collection
    public async Task<bool> Update(CollectionFlashcard collection)
    {
        try
        {
            
            _db.CollectionFlashcards.Update(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionFlashcardRepository] collection FindAsync(id) failed when updating the CollectionFlashcardId " +
                "{CollectionFlashcardId:0000}, error message {e}", collection, e.Message);
            return false;
        }
       
    }

    // Deletes a collection
    public async Task<bool> Delete(int id)
    {
        try
        {
            var collection = await _db.CollectionFlashcards.FindAsync(id);
            if (collection == null)
            {
                _logger.LogError("[CollectionFlashcardRepository] collection not found for the CollectionFlashcardId {CollectionFlashcardId:0000}", id);
                return false;
            }

            _db.CollectionFlashcards.Remove(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("CollectionFlashcardRepository] collection deletion failed for CollectionFlashcardId {CollectionFlashcardId:0000}, " +
                "error message: {e}", id, e.Message);
            return false;
        }
        
    }
}
