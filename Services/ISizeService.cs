using Project_01.DTO.Size;

namespace Project_01.Services;

public interface ISizeService
{
    List<SizeResponse> GetAllSizes();
    
    SizeResponse GetSizeById(int id);
    
    void InsertSize(SizeRequest sizeRequest);
    
    void EditSize(SizeRequest sizeRequest, int id);
}