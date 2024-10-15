namespace Project_01.DTO.ProductDetail;

public class ProductDetailResponse
{
    public int Id { get; set; }
    
    public int Quantity;
    
    public double Price { get; set; }
    
    public bool Status { get; set; } = true;
    
    public string ColorName { get; set; } 
    
    public string SizeName { get; set; } 
    
    public string ProductName { get; set; } 
}