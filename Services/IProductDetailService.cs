using Project_01.DTO.ProductDetail;

namespace Project_01.Services;

public interface IProductDetailService
{
    List<ProductDetailResponse> getAllProductDetails();
    
    ProductDetailResponse getProductDetailById(int id);
    
    void insertProductDetail(ProductDetailRequest productDetailRequest);
    
    void editProductDetail(ProductDetailRequest productDetailRequest, int id);
    
    List<ProductDetailResponse> getProductDetailByProductId(int productId);
}