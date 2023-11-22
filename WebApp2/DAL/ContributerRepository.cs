using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApp2.DAL;
using WebApp2.Models;

namespace MyShop.DAL;
//namespace WebApp1.DAL;

public class ContributerRepository : IContributerRepository
{

    private readonly FlashcardDbContext _db;
    private readonly ILogger<ContributerRepository> _logger;

    public ContributerRepository(FlashcardDbContext db, ILogger<ContributerRepository> logger)
    {
        _db = db;
        _logger = logger;
    }


    //Gets every contributer
    public async Task<IEnumerable<Contributer>?> GetAll()
    {
        try 
        {
            return await _db.Contributers.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[ContributerRepository] Contributers ToListAsync() failed when GetAll() was called, error message: {e}", e.Message);
            return null;
        }
    }

    // Gets a single contributer by id
    public async Task<Contributer?> GetContributerById(int id)
    {
        try
        {
            return await _db.Contributers.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[ContributerRepository] contributer FindAsync(id) failed when GetContributerById " +
                "for ContributerId {ContributerId:0000}, error message: {e}", id, e.Message);
            return null;
        }
    }

    // Creates a new contributer
    public async Task<bool> Create(Contributer contributer)
    {
        try
        {
            _db.Contributers.Add(contributer);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ContributerRepository] contributer creation failed for contributer {@contributer}, error message: {e}", contributer, e.Message);
            return false;
        }
    }

    // Updates an exsisting contributer
    public async Task<bool> Update(Contributer contributer)
    {
        try
        {
            
            _db.Contributers.Update(contributer);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ContributerRepository] contributer FindAsync(id) failed when updating the ContributerId " +
                "{ContributerId:0000}, error message {e}", contributer, e.Message);
            return false;
        }
       
    }

    // Deletes a contributer
    public async Task<bool> Delete(int id)
    {
        try
        {
            var contributer = await _db.Contributers.FindAsync(id);
            if (contributer == null)
            {
                _logger.LogError("[ContributerRepository] contributer not found for the ContributerId {ContributerId:0000}", id);
                return false;
            }

            _db.Contributers.Remove(contributer);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("ContributerRepository] contributer deletion failed for ContributerId {ContributerId:0000}, " +
                "error message: {e}", id, e.Message);
            return false;
        }
        
    }
}
