using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PlayController : ControllerBase
{
    private readonly FlashcardDbContext _context;

    public PlayController(FlashcardDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flashcard>>> GetFlashcards()
    {
        return await _context.Flashcards.ToListAsync();
    }
}