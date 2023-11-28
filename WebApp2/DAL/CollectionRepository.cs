using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApp2.DAL;
using WebApp2.Models;

namespace MyShop.DAL;
//namespace WebApp1.DAL;

public class CollectionRepository : ICollectionRepository
{

    private readonly FlashcardDbContext _db;
    private readonly ILogger<CollectionRepository> _logger;

    public CollectionRepository(FlashcardDbContext db, ILogger<CollectionRepository> logger)
    {
        _db = db;
        _logger = logger;
    }


    //Gets every collection
    public async Task<IEnumerable<Collection>?> GetAll()
    {
        try 
        {
            return await _db.Collections.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionRepository] Collections ToListAsync() failed when GetAll() was called, error message: {e}", e.Message);
            return null;
        }
    }

    // Gets a single collection by id
    public async Task<Collection?> GetCollectionById(int id)
    {
        try
        {
            return await _db.Collections.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionRepository] collection FindAsync(id) failed when GetCollectionById " +
                "for CollectionId {CollectionId:0000}, error message: {e}", id, e.Message);
            return null;
        }
    }

    // Creates a new collection
    public async Task<bool> Create(Collection collection)
    {
        try
        {
            _db.Collections.Add(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"[CollectionRepository] collection creation failed for collection {@collection}, error message: {e}, {e.InnerException?.Message}", collection, e.Message, e.InnerException?.Message);
            return false;
        }
    }

    // Updates an exsisting collection
    public async Task<bool> Update(Collection collection)
    {
        try
        {
            
            _db.Collections.Update(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[CollectionRepository] collection FindAsync(id) failed when updating the CollectionId " +
                "{CollectionId:0000}, error message {e}", collection, e.Message);
            return false;
        }
       
    }

    // Deletes a collection
    public async Task<bool> Delete(int id)
    {
        try
        {
            var collection = await _db.Collections.FindAsync(id);
            if (collection == null)
            {
                _logger.LogError("[CollectionRepository] collection not found for the CollectionId {CollectionId:0000}", id);
                return false;
            }

            _db.Collections.Remove(collection);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("CollectionRepository] collection deletion failed for CollectionId {CollectionId:0000}, " +
                "error message: {e}", id, e.Message);
            return false;
        }
        
    }
}
