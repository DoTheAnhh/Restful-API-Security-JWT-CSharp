using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.Product;
using Project_01.Services;

namespace Project_01.Controllers;

[Route("/product")]
[ApiController]
public class ProductController : ControllerBase
{
     private readonly IProductService _productService;

     public ProductController(IProductService productService)
     {
          _productService = productService;
     }

     [HttpGet]
     public ActionResult<List<ProductResponse>> GetAllProducts()
     {
          try
          {
               var products = _productService.getAllProduct();
               return Ok(products);
          }
          catch (Exception ex)
          {
               return StatusCode(500, $"Internal server error: {ex.Message}");
          }
     }

     [HttpGet("{id:int}")]
     public ActionResult<ProductResponse> GetProductById(int id)
     {
          try
          {
               var product = _productService.findProductById(id);
               if (product == null)
               {
                    return NotFound($"Product with ID {id} not found.");
               }
               return Ok(product);
          }
          catch (Exception ex)
          {
               return StatusCode(500, $"Internal server error: {ex.Message}");
          }
     }

     [HttpPost("insert")]
     [Authorize(Policy = "AdminOnly")]
     public ActionResult InsertProduct([FromBody] ProductRequest productRequest)
     {
          try
          {
               if (ModelState.IsValid)
               {
                    _productService.insertProduct(productRequest);
                    return Ok("Product added successfully.");
               }
               return BadRequest("Invalid product data.");
          }
          catch (Exception ex)
          {
               return StatusCode(500, $"Internal server error: {ex.Message}");
          }
     }

     [HttpPut("edit/{id:int}")]
     [Authorize(Policy = "AdminOnly")]
     public ActionResult EditProduct(int id, [FromBody] ProductRequest productRequest)
     {
          try
          {
               if (ModelState.IsValid)
               {
                    _productService.editProduct(productRequest, id);
                    return Ok("Product updated successfully.");
               }
               return BadRequest("Invalid product data.");
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
     
     [HttpGet("type/{typeId:int}")]
     public ActionResult<List<ProductResponse>> GetProductsByTypeId(int typeId)
     {
          try
          {
               var products = _productService.getProductsByType(typeId);
               if (products == null || products.Count == 0)
               {
                    return NotFound($"No products found for type ID {typeId}.");
               }
               return Ok(products);
          }
          catch (Exception ex)
          {
               return StatusCode(500, $"Internal server error: {ex.Message}");
          }
     }
}