using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardController : Controller
{
    
    private readonly IFlashcardRepository _flashcardRepository;
    private readonly ILogger<FlashcardController> _logger;

    public FlashcardController(IFlashcardRepository flashcardRepository, ILogger<FlashcardController> logger)
    {
        _flashcardRepository = flashcardRepository;
        _logger = logger;

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _flashcardRepository.GetAll();
        if (items == null)
        {
            _logger.LogError("[ItemController] Item list not found while executing _itemRepository.GetAll()");
            return NotFound("Item list not found");
        }
        return Ok(items);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Flashcard newItem)
    {
        if (newItem == null)
        {
            return BadRequest("Invalid item data.");
        }
        //newItem.ItemId = GetNextItemId();
        bool returnOk = await _flashcardRepository.Create(newItem);

        if (returnOk)
        {
            var response = new { success = true, message = "Item " + newItem.Name + " created successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Item creation failed" };
            return Ok(response);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFlashcardbyId(int id)
    {
        var flashcard = await _flashcardRepository.GetFlashcardById(id);
        if (flashcard == null)
        {
            _logger.LogError("[FlashcardController] Flashcard list not found while executing _flashcardRepository.GetAll()");
            return NotFound("Flashcard list not found");
        }
        return Ok(flashcard);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(Flashcard newFlashcard)
    {
        if(newFlashcard == null)
        {
            return BadRequest("Invalid flashcard data");
        }
        bool returnOk = await _flashcardRepository.Update(newFlashcard);
        if (returnOk) 
        {
            var response = new { success = true, message = "Flashcard " + newFlashcard.Name + " updated successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Flashcard creation failed" };
            return Ok(response);
        }
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteFlashcard(int id)
    {
        bool returnOk = await _flashcardRepository.Delete(id);
        if (!returnOk)
        {
            _logger.LogError("[FlashcardController] Flashcard deletion failed for the FlashcardId {FlashcardId: 0000}", id);
            return BadRequest("Flashcard deletion failed");
        }
        var response = new { success = true, message = "Flashcard " + id.ToString() + " Deleted successfully" };
        return Ok(response);
    }
}

    //private static int GetNextItemId()
    //{
    //    if (Items.Count == 0)
    //    {
    //        return 1;
    //    }
    //    return Items.Max(item => item.ItemId) + 1;
    //}