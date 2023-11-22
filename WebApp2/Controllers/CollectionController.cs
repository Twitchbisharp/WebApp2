using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionController : Controller
{
    
    private readonly ICollectionRepository _collectionRepository;
    private readonly ILogger<CollectionController> _logger;

    public CollectionController(ICollectionRepository collectionRepository, ILogger<CollectionController> logger)
    {
        _collectionRepository = collectionRepository;
        _logger = logger;

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var collections = await _collectionRepository.GetAll();
        if (collections == null)
        {
            _logger.LogError("[CollectionController] Collection list not found while executing _collectionRepository.GetAll()");
            return NotFound("Collection list not found");
        }
        return Ok(collections);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Collection newCollection)
    {
        if (newCollection == null)
        {
            return BadRequest("Invalid collection data.");
        }
        //newCollection.CollectionId = GetNextCollectionId();
        bool returnOk = await _collectionRepository.Create(newCollection);

        if (returnOk)
        {
            var response = new { success = true, message = "Collection " + newCollection.CollectionName + " created successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Collection creation failed" };
            return Ok(response);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollectionbyId(int id)
    {
        var collection = await _collectionRepository.GetCollectionById(id);
        if (collection == null)
        {
            _logger.LogError("[CollectionController] Collection list not found while executing _collectionRepository.GetAll()");
            return NotFound("Collection list not found");
        }
        return Ok(collection);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(Collection newCollection)
    {
        //// Add date updater
        newCollection.CollectionDate = DateTime.Now.ToString("dd/MM/yyyy");
        _logger.LogInformation("new collection: ", newCollection);
        if (newCollection == null)
        {
            return BadRequest("Invalid collection data");
        }
        bool returnOk = await _collectionRepository.Update(newCollection);
        if (returnOk) 
        {
            var response = new { success = true, message = "Collection " + newCollection.CollectionName + " updated successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Collection creation failed" };
            return Ok(response);
        }
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCollection(int id)
    {
        bool returnOk = await _collectionRepository.Delete(id);
        if (!returnOk)
        {
            _logger.LogError("[CollectionController] Collection deletion failed for the CollectionId {CollectionId: 0000}", id);
            return BadRequest("Collection deletion failed");
        }
        var response = new { success = true, message = "Collection " + id.ToString() + " Deleted successfully" };
        return Ok(response);
    }
}

    //private static int GetNextCollectionId()
    //{
    //    if (Collections.Count == 0)
    //    {
    //        return 1;
    //    }
    //    return Collections.Max(collection => collection.CollectionId) + 1;
    //}