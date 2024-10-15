using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.Color;
using Project_01.Services;

namespace Project_01.Controllers;

[Route("/color")]
[ApiController]
public class ColorController : ControllerBase
{
    private readonly IColorService _colorService;

    public ColorController(IColorService colorService)
    {
        _colorService = colorService;
    }
    
    [HttpGet]
    public ActionResult<List<ColorResponse>> GetAllColors()
    {
        try
        {
            var color = _colorService.GetAllColors();
            return Ok(color);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<ColorResponse> GetColorById(int id)
    {
        try
        {
            var color = _colorService.GetColorById(id);
            if (color == null)
            {
                return NotFound($"Color with ID {id} not found.");
            }
            return Ok(color);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("insert")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult InsertColor([FromBody] ColorRequest colorRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _colorService.InsertColor(colorRequest);
                return Ok("Color added successfully.");
            }
            return BadRequest("Invalid color data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("edit/{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult EditColor(int id, [FromBody] ColorRequest colorRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _colorService.EditColor(colorRequest, id);
                return Ok("Color updated successfully.");
            }
            return BadRequest("Invalid color data.");
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