using Project_01.DTO.Type;

namespace Project_01.Services;

public interface ITypeService
{
    List<TypeResponse> getAllTypes();
    
    TypeResponse getTypeById(int id);
    
    void insertType(TypeRequest typeRequest);
    
    void updateType(TypeRequest typeRequest, int id);
}