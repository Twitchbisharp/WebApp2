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
}
