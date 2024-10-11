using Microsoft.EntityFrameworkCore;
using Project_01.Data;
using Project_01.Models;

namespace Project_01.Repositories;

public class ProductRepository
{
    private readonly MyDBContext _context;

    public ProductRepository (MyDBContext context)
    {
        _context = context;
    }
    
    public List<Product> GetProductsByType(int typeId)
    {
        var products = _context.Products
            .FromSqlRaw("SELECT * FROM Product WHERE TypeId = {0}", typeId)
            .Include(p => p.Type)
            .ToList();
        return products;
    }
}