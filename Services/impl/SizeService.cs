using AutoMapper;
using Project_01.Data;
using Project_01.DTO.Size;
using Project_01.Models;

namespace Project_01.Services.impl;

public class SizeService : ISizeService
{
    private readonly MyDBContext _context;
    
    private readonly IMapper _mapper;

    public SizeService(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public List<SizeResponse> GetAllSizes()
    {
        return _mapper.Map<List<SizeResponse>>(_context.Sizes.ToList());
    }

    public SizeResponse GetSizeById(int id)
    {
        var size = _context.Sizes.FirstOrDefault(s => s.Id == id);
        if (size == null)
        {
            throw new KeyNotFoundException($"Size with id {id} not found.");
        }
        return _mapper.Map<SizeResponse>(size);
    }

    public void InsertSize(SizeRequest sizeRequest)
    {
        var size = _mapper.Map<Size>(sizeRequest);
        _context.Sizes.Add(size);
        _context.SaveChanges();
    }

    public void EditSize(SizeRequest sizeRequest, int id)
    {
        var size = _context.Sizes.FirstOrDefault(s => s.Id == id);
        if (size == null)
        {
            throw new KeyNotFoundException($"Size with id {id} not found.");
        }
        _mapper.Map(sizeRequest, size);
        _context.SaveChanges();
    }
}