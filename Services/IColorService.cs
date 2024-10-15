using Project_01.DTO.Color;

namespace Project_01.Services;

public interface IColorService
{
    List<ColorResponse> GetAllColors();
    
    ColorResponse GetColorById(int id);
    
    void InsertColor(ColorRequest colorRequest);
    
    void EditColor(ColorRequest colorRequest, int id);
}
