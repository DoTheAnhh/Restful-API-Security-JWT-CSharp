using Project_01.DTO.Brand;

namespace Project_01.Services;

public interface IBrandService
{
    List<BrandResponse> getAllBrands();
    
    BrandResponse getBrandById(int id);
    
    void insertBrand(BrandRequest brand);
    
    void editBrand(BrandRequest brand, int id);
}