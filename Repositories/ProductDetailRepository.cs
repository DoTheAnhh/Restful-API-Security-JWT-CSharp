using Microsoft.EntityFrameworkCore;
using Project_01.Data;
using Project_01.Models;

namespace Project_01.Repositories;

public class ProductDetailRepository
{
    private readonly MyDBContext _context;

    public ProductDetailRepository(MyDBContext context)
    {
        _context = context;
    }

    public List<ProductDetail> GetProductDetailByProductId(int productId)
    {
        var products = _context.ProductDetails
            .FromSqlRaw("SELECT * FROM ProductDetail WHERE ProductId = {0}", productId)
            .Include(p => p.Product)
            .ToList();
        return products;
    }
}