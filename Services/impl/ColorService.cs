using AutoMapper;
using Project_01.Data;
using Project_01.DTO.Color;
using Project_01.Models;

namespace Project_01.Services.impl;

public class ColorService : IColorService
{
    private readonly MyDBContext _context;
    
    private readonly IMapper _mapper;

    public ColorService(MyDBContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public List<ColorResponse> GetAllColors()
    {
        return _mapper.Map<List<ColorResponse>>(_context.Colors.ToList());
    }

    public ColorResponse GetColorById(int id)
    {
        var color = _context.Colors.FirstOrDefault(c => c.Id == id);
        if (color == null)
        {
            throw new KeyNotFoundException($"Color with id {id} not found.");
        }
        return _mapper.Map<ColorResponse>(color);
    }

    public void InsertColor(ColorRequest colorRequest)
    {
        var color = _mapper.Map<Color>(colorRequest);
        _context.Colors.Add(color);
        _context.SaveChanges();
    }

    public void EditColor(ColorRequest colorRequest, int id)
    {
        var color = _context.Colors.FirstOrDefault(c => c.Id == id);
        if (color == null)
        {
            throw new KeyNotFoundException($"Color with id {id} not found.");
        }
        _mapper.Map(colorRequest, color);
        _context.SaveChanges();
    }
}