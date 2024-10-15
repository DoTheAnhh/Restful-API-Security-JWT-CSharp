using AutoMapper;
using Project_01.Data;
using Project_01.DTO.Brand;
using Project_01.Models;

namespace Project_01.Services.impl;

public class BrandService : IBrandService
{
    private readonly MyDBContext _context;
    
    private readonly IMapper _mapper;

    public BrandService(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public List<BrandResponse> getAllBrands()
    {
        return _mapper.Map<List<BrandResponse>>(_context.Brands.ToList());
    }

    public BrandResponse getBrandById(int id)
    {
        var brand = _context.Brands.FirstOrDefault(b => b.Id == id);
        if (brand == null)
        {
            throw new KeyNotFoundException($"Brand with id {id} not found.");
        }
        return _mapper.Map<BrandResponse>(brand);
    }

    public void insertBrand(BrandRequest brandRequest)
    {
        var brand = _mapper.Map<Brand>(brandRequest);
        _context.Brands.Add(brand);
        _context.SaveChanges();
    }

    public void editBrand(BrandRequest brandRequest, int id)
    {
        var brand = _context.Brands.FirstOrDefault(b => b.Id == id);
        if (brand == null)
        {
            throw new KeyNotFoundException($"Type with id {id} not found.");
        }
        _mapper.Map(brandRequest, brand);
        _context.SaveChanges();
    }
}