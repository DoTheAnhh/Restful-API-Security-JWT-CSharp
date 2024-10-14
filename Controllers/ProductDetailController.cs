using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.ProductDetail;
using Project_01.Services;

namespace Project_01.Controllers;

[Route("/product-detail")]
[ApiController]
public class ProductDetailController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }
    
    [HttpGet]
    public ActionResult<List<ProductDetailResponse>> GetAllProductDetails()
    {
        try
        {
            var productDetails = _productDetailService.getAllProductDetails();
            return Ok(productDetails);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<ProductDetailResponse> GetProductDetailById(int id)
    {
        try
        {
            var productDetail = _productDetailService.getProductDetailById(id);
            if (productDetail == null)
            {
                return NotFound($"Product detail with ID {id} not found.");
            }
            return Ok(productDetail);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("insert")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult InsertProductDetail([FromBody] ProductDetailRequest productDetailRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _productDetailService.insertProductDetail(productDetailRequest);
                return Ok("Product detail added successfully.");
            }
            return BadRequest("Invalid product detail data.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("edit/{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public ActionResult EditProduct(int id, [FromBody] ProductDetailRequest productDetailRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _productDetailService.editProductDetail(productDetailRequest, id);
                return Ok("Product detail updated successfully.");
            }
            return BadRequest("Invalid product detail data.");
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
    
    [HttpGet("product/{productId:int}")]
    public ActionResult<List<ProductDetailResponse>> GetProductDetailsByProductId(int productId)
    {
        try
        {
            var products = _productDetailService.getProductDetailByProductId(productId);
            if (products == null || products.Count == 0)
            {
                return NotFound($"No product details found for type ID {productId}.");
            }
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}