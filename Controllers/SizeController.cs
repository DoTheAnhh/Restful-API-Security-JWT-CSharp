using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.Size;
using Project_01.Services;

namespace Project_01.Controllers;

[Route("/size")]
[ApiController]
public class SizeController : ControllerBase
{
    private readonly ISizeService _sizeService;

    public SizeController(ISizeService sizeService)
    {
        _sizeService = sizeService;
    }
    
    [HttpGet]
    public ActionResult<List<SizeResponse>> GetAllSizes()
    {
        try
        {
            var size = _sizeService.GetAllSizes();
            return Ok(size);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<SizeResponse> GetSizeById(int id)
    {
        try
        {
            var size = _sizeService.GetSizeById(id);
            if (size == null)
            {
                return NotFound($"Size with ID {id} not found.");
            }
            return Ok(size);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("insert")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult InsertSize([FromBody] SizeRequest sizeRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _sizeService.InsertSize(sizeRequest);
                return Ok("Size added successfully.");
            }
            return BadRequest("Invalid size data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("edit/{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult EditSize(int id, [FromBody] SizeRequest sizeRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _sizeService.EditSize(sizeRequest, id);
                return Ok("Size updated successfully.");
            }
            return BadRequest("Invalid size data.");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}