using AutoMapper;
using Project_01.Data;
using Project_01.DTO.Type;
using Project_01.Services;
using Type = Project_01.Models.Type;

public class TypeService : ITypeService
{
    
    private readonly IMapper _mapper;
    
    private readonly MyDBContext _context;

    public TypeService(IMapper mapper, MyDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public List<TypeResponse> getAllTypes()
    {
        return _mapper.Map<List<TypeResponse>>(_context.Types.ToList());
    }

    public TypeResponse getTypeById(int id)
    {
        var type = _context.Types.FirstOrDefault(t => t.TypeId == id);
        if (type == null)
        {
            throw new KeyNotFoundException($"Type with id {id} not found.");
        }
        return _mapper.Map<TypeResponse>(type);
    }

    public void insertType(TypeRequest typeRequest)
    {
        var type = _mapper.Map<Type>(typeRequest);
        _context.Types.Add(type);
        _context.SaveChanges();
    }

    public void updateType(TypeRequest typeRequest, int id)
    {
        var type = _context.Types.FirstOrDefault(t => t.TypeId == id);
        if (type == null)
        {
            throw new KeyNotFoundException($"Type with id {id} not found.");
        }
        _mapper.Map(typeRequest, type);
        _context.SaveChanges();
    }
}