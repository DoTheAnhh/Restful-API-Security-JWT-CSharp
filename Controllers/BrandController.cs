using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.Brand;
using Project_01.Services;

namespace Project_01.Controllers;

[Route("/brand")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public ActionResult<List<BrandResponse>> GetAllBrands()
    {
        try
        {
            var brand = _brandService.getAllBrands();
            return Ok(brand);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<BrandResponse> GetBrandById(int id)
    {
        try
        {
            var brand = _brandService.getBrandById(id);
            if (brand == null)
            {
                return NotFound($"Brand with ID {id} not found.");
            }
            return Ok(brand);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("insert")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult InsertBrand([FromBody] BrandRequest brandRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _brandService.insertBrand(brandRequest);
                return Ok("Brand added successfully.");
            }
            return BadRequest("Invalid brand data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("edit/{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult EditBrand(int id, [FromBody] BrandRequest brandRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _brandService.editBrand(brandRequest, id);
                return Ok("Brand updated successfully.");
            }
            return BadRequest("Invalid brand data.");
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