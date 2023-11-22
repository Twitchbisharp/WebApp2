using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.DAL;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContributerController : Controller
{
    
    private readonly IContributerRepository _contributerRepository;
    private readonly ILogger<ContributerController> _logger;

    public ContributerController(IContributerRepository contributerRepository, ILogger<ContributerController> logger)
    {
        _contributerRepository = contributerRepository;
        _logger = logger;

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contributers = await _contributerRepository.GetAll();
        if (contributers == null)
        {
            _logger.LogError("[ContributerController] Contributer list not found while executing _contributerRepository.GetAll()");
            return NotFound("Contributer list not found");
        }
        return Ok(contributers);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Contributer newContributer)
    {
        if (newContributer == null)
        {
            return BadRequest("Invalid contributer data.");
        }
        //newContributer.ContributerId = GetNextContributerId();
        bool returnOk = await _contributerRepository.Create(newContributer);

        if (returnOk)
        {
            var response = new { success = true, message = "Contributer " + newContributer.Name + " created successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Contributer creation failed" };
            return Ok(response);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContributerbyId(int id)
    {
        var contributer = await _contributerRepository.GetContributerById(id);
        if (contributer == null)
        {
            _logger.LogError("[ContributerController] Contributer list not found while executing _contributerRepository.GetAll()");
            return NotFound("Contributer list not found");
        }
        return Ok(contributer);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(Contributer newContributer)
    {
        if(newContributer == null)
        {
            return BadRequest("Invalid contributer data");
        }
        bool returnOk = await _contributerRepository.Update(newContributer);
        if (returnOk) 
        {
            var response = new { success = true, message = "Contributer " + newContributer.Name + " updated successfully" };
            return Ok(response);
        }
        else
        {
            var response = new { success = false, message = "Contributer creation failed" };
            return Ok(response);
        }
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteContributer(int id)
    {
        bool returnOk = await _contributerRepository.Delete(id);
        if (!returnOk)
        {
            _logger.LogError("[ContributerController] Contributer deletion failed for the ContributerId {ContributerId: 0000}", id);
            return BadRequest("Contributer deletion failed");
        }
        var response = new { success = true, message = "Contributer " + id.ToString() + " Deleted successfully" };
        return Ok(response);
    }
}

    //private static int GetNextContributerId()
    //{
    //    if (Contributers.Count == 0)
    //    {
    //        return 1;
    //    }
    //    return Contributers.Max(contributer => contributer.ContributerId) + 1;
    //}