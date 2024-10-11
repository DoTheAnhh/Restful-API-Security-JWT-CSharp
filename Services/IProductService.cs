using Project_01.DTO.Product;

namespace Project_01.Services;

public interface IProductService
{
    List<ProductResponse> getAllProduct();
    
    ProductResponse findProductById(int id);
    
    void insertProduct(ProductRequest productRequest);
    
    void editProduct(ProductRequest productRequest, int id);

    List<ProductResponse> getProductsByType(int typeId);
}