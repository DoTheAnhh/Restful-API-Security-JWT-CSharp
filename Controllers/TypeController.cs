using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.Type;
using Project_01.Services;

namespace Project_01.DTO;

[Route("/type")]
[ApiController]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }
    
    [HttpGet]
    public ActionResult<List<TypeResponse>> GetAllTypes()
    {
        try
        {
            var type = _typeService.getAllTypes();
            return Ok(type);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<TypeResponse> GetTypeById(int id)
    {
        try
        {
            var type = _typeService.getTypeById(id);
            if (type == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(type);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("insert")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult InsertType([FromBody] TypeRequest typeRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _typeService.insertType(typeRequest);
                return Ok("Type added successfully.");
            }
            return BadRequest("Invalid type data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("edit/{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult EditType(int id, [FromBody] TypeRequest typeRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _typeService.updateType(typeRequest, id);
                return Ok("Type updated successfully.");
            }
            return BadRequest("Invalid type data.");
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