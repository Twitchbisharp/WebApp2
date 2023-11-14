using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebApp2.DAL;
using WebApp2.Models;

namespace MyShop.DAL;
//namespace WebApp1.DAL;

public class FlashcardRepository : IFlashcardRepository
{

    private readonly FlashcardDbContext _db;
    private readonly ILogger<FlashcardRepository> _logger;

    public FlashcardRepository(FlashcardDbContext db, ILogger<FlashcardRepository> logger)
    {
        _db = db;
        _logger = logger;
    }


    //Gets every flashcard
    public async Task<IEnumerable<Flashcard>?> GetAll()
    {
        try 
        {
            return await _db.Flashcards.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[FlashcardRepository] Flashcards ToListAsync() failed when GetAll() was called, error message: {e}", e.Message);
            return null;
        }
    }

    // Gets a single flashcard by id
    public async Task<Flashcard?> GetFlashcardById(int id)
    {
        try
        {
            return await _db.Flashcards.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[FlashcardRepository] flashcard FindAsync(id) failed when GetFlashcardById " +
                "for FlashcardId {FlashcardId:0000}, error message: {e}", id, e.Message);
            return null;
        }
    }

    // Creates a new flashcard
    public async Task<bool> Create(Flashcard flashcard)
    {
        try
        {
            _db.Flashcards.Add(flashcard);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[FlashcardRepository] flashcard creation failed for flashcard {@flashcard}, error message: {e}", flashcard, e.Message);
            return false;
        }
    }

    // Updates an exsisting flashcard
    public async Task<bool> Update(Flashcard flashcard)
    {
        try
        {
            _db.Flashcards.Update(flashcard);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[FlashcardRepository] flashcard FindAsync(id) failed when updating the FlashcardId " +
                "{FlashcardId:0000}, error message {e}", flashcard, e.Message);
            return false;
        }
       
    }

    // Deletes a flashcard
    public async Task<bool> Delete(int id)
    {
        try
        {
            var flashcard = await _db.Flashcards.FindAsync(id);
            if (flashcard == null)
            {
                _logger.LogError("[FlashcardRepository] flashcard not found for the FlashcardId {FlashcardId:0000}", id);
                return false;
            }

            _db.Flashcards.Remove(flashcard);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("FlashcardRepository] flashcard deletion failed for FlashcardId {FlashcardId:0000}, " +
                "error message: {e}", id, e.Message);
            return false;
        }
        
    }
}
