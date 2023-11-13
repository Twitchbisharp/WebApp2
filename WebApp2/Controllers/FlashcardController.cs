using Microsoft.AspNetCore.Mvc;
    using WebApp2.Models;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardController : Controller
{
    private static List<Flashcard> Flashcards = new List<Flashcard>()
    {
        new Flashcard()
        {
            FlashcardId = 1,
            Name = "House",
            Description = "Hus",
            ImageUrl = "/assets/images/test.jpg"
        },
        new Flashcard()
        {
            FlashcardId = 2,
            Name = "KFC",
            Description = "Kentukky Fried Chicken",
            ImageUrl = "/assets/images/kfc.jpg"
        },
    };

    [HttpGet]
    public List<Flashcard> GetAll()
    {
        return Flashcards;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] Flashcard newFlashcard)
    {
        if (newFlashcard == null)
        {
            return BadRequest("Invalid flashcard data.");
        }
        newFlashcard.FlashcardId = GetNextFlashcardId();
        Flashcards.Add(newFlashcard);

        var response = new { success = true, message = "Flashcard" + newFlashcard.Name + " created successfully" };
        return Ok(response);
    }
    private static int GetNextFlashcardId()
    {
        if (Flashcards.Count == 0)
        {
            return 1;
        }
        return Flashcards.Max(flashcard => flashcard.FlashcardId) + 1;
    }
}
