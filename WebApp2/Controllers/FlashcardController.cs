using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardController : Controller
{
    private readonly IFlashcardRepository flashcardRepository;
    private readonly ILogger<FlashcardController> logger;
    private IFlashcardRepository _flashcardRepository;
    private ILogger<FlashcardController> _logger;

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
}

    //private static int GetNextItemId()
    //{
    //    if (Items.Count == 0)
    //    {
    //        return 1;
    //    }
    //    return Items.Max(item => item.ItemId) + 1;
    //}