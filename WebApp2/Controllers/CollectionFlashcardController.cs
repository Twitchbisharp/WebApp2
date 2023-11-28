using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/collectionFlashcard")]
public class CollectionFlashcardController : Controller
{
    
    private readonly ICollectionFlashcardRepository _collectionFlashcardRepository;
    private readonly ILogger<CollectionFlashcardController> _logger;

    public CollectionFlashcardController(ICollectionFlashcardRepository collectionFlashcardRepository, ILogger<CollectionFlashcardController> logger)
    {
        _collectionFlashcardRepository = collectionFlashcardRepository;
        _logger = logger;

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogError("Inside GetAll in CollectionFlashcardController, url: api/collectionFlashcard" );
        var collectionFlashcards = await _collectionFlashcardRepository.GetAll();
        if (collectionFlashcards == null)
        {
            _logger.LogError("[CollectionFlashcardController] CollectionFlashcard list not found while executing _collectionFlashcardRepository.GetAll()");
            return NotFound("CollectionFlashcard list not found");
        }
        return Ok(collectionFlashcards);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CollectionFlashcard newCollectionFlashcard)
    {
        _logger.LogError("Inside Create collectionFlashcardController");
        if (newCollectionFlashcard == null)
        {
            return BadRequest("Invalid collectionFlashcard data.");
        }
        //newCollectionFlashcard.CollectionFlashcardId = GetNextCollectionFlashcardId();
        bool returnOk = await _collectionFlashcardRepository.Create(newCollectionFlashcard);
        _logger.LogError("Inside Create in collectionflashcardController with returnOK being: ", returnOk);
        if (returnOk)
        {
            var response = new { success = true, message = "CollectionFlashcard " + newCollectionFlashcard.CollectionFlashcardId + " created successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "CollectionFlashcard creation failed" };
            return Ok(response);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollectionFlashcardByCollectionId(int id)
    {
        var collectionFlashcard = await _collectionFlashcardRepository.GetCollectionFlashcardById(id);
        if (collectionFlashcard == null)
        {
            _logger.LogError("[CollectionFlashcardController] CollectionFlashcard list not found while executing _collectionFlashcardRepository.GetAll()");
            return NotFound("CollectionFlashcard list not found");
        }
        return Ok(collectionFlashcard);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(CollectionFlashcard newCollectionFlashcard)
    {
     
        if (newCollectionFlashcard == null)
        {
            return BadRequest("Invalid collectionFlashcard data");
        }
        bool returnOk = await _collectionFlashcardRepository.Update(newCollectionFlashcard);
        if (returnOk) 
        {
            var response = new { success = true, message = "CollectionFlashcard " + newCollectionFlashcard.CollectionFlashcardId + " updated successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "CollectionFlashcard creation failed" };
            return Ok(response);
        }
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCollectionFlashcard(int id)
    {
        bool returnOk = await _collectionFlashcardRepository.Delete(id);
        if (!returnOk)
        {
            _logger.LogError("[CollectionFlashcardController] CollectionFlashcard deletion failed for the CollectionFlashcardId {CollectionFlashcardId: 0000}", id);
            return BadRequest("CollectionFlashcard deletion failed");
        }
        var response = new { success = true, message = "CollectionFlashcard " + id.ToString() + " Deleted successfully" };
        return Ok(response);
    }
}

    //private static int GetNextCollectionFlashcardId()
    //{
    //    if (CollectionFlashcards.Count == 0)
    //    {
    //        return 1;
    //    }
    //    return CollectionFlashcards.Max(collectionFlashcard => collectionFlashcard.CollectionFlashcardId) + 1;
    //}