using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_01.Data;
using Project_01.DTO.Product;
using Project_01.Models;
using Project_01.Repositories;

namespace Project_01.Services.impl;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    
    private readonly MyDBContext _context;
    
    private readonly ProductRepository _productRepository;
    

    public ProductService(IMapper mapper, MyDBContext context, ProductRepository productRepository)
    {
        _mapper = mapper;
        _context = context;
        _productRepository = productRepository;
    }
    
    public List<ProductResponse> getAllProduct()
    {
        var products = _context.Products.Include(p => p.Type).ToList();
        return _mapper.Map<List<ProductResponse>>(products);
    }

    public ProductResponse findProductById(int id)
    {
        var product = _context.Products.Include(p => p.Type).FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found.");
        }
        return _mapper.Map<ProductResponse>(product);
    }

    public void insertProduct(ProductRequest productRequest)
    {
        var product = _mapper.Map<Product>(productRequest);
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void editProduct(ProductRequest productRequest, int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found.");
        }
        _mapper.Map(productRequest, product);
        _context.SaveChanges();
    }

    public List<ProductResponse> getProductsByType(int typeId)
    {
        var products = _productRepository.GetProductsByType(typeId);
        return _mapper.Map<List<ProductResponse>>(products);
    }
}