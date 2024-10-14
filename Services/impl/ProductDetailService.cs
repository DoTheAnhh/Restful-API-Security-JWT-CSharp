using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_01.Data;
using Project_01.DTO.Product;
using Project_01.DTO.ProductDetail;
using Project_01.Models;
using Project_01.Repositories;

namespace Project_01.Services.impl;

public class ProductDetailService : IProductDetailService
{
    
    private readonly IMapper _mapper;
    
    private readonly MyDBContext _context;
    
    private readonly ProductDetailRepository _productDetailRepository;

    public ProductDetailService(IMapper mapper, MyDBContext context, ProductDetailRepository productDetailRepository)
    {
        _mapper = mapper;
        _context = context;
        _productDetailRepository = productDetailRepository;
    }
    
    public List<ProductDetailResponse> getAllProductDetails()
    {
        var productDetails = _context.ProductDetails
                                                                    .Include(pd => pd.Product)
                                                                    .Include(pd => pd.Size)
                                                                    .Include(pd => pd.Color)
                                                                    .ToList();
        return _mapper.Map<List<ProductDetailResponse>>(productDetails);
    }

    public ProductDetailResponse getProductDetailById(int id)
    {
        var productDetails = _context.ProductDetails
                                                                    .Include(pd => pd.Product)
                                                                    .Include(pd => pd.Size)
                                                                    .Include(pd => pd.Color)
                                                                    .FirstOrDefault(pd => pd.Id == id);
        if (productDetails == null)
        {
            throw new KeyNotFoundException($"Product detail with id {id} not found.");
        }
        return _mapper.Map<ProductDetailResponse>(productDetails);
    }

    public void insertProductDetail(ProductDetailRequest productDetailRequest)
    {
        var productDetail = _mapper.Map<ProductDetail>(productDetailRequest);
        _context.ProductDetails.Add(productDetail);
        _context.SaveChanges();
    }

    public void editProductDetail(ProductDetailRequest productDetailRequest, int id)
    {
        var productDetails = _context.ProductDetails
                                                                .Include(pd => pd.Product)
                                                                .Include(pd => pd.Size)
                                                                .Include(pd => pd.Color)
                                                                .FirstOrDefault(pd => pd.Id == id);
        if (productDetails == null)
        {
            throw new KeyNotFoundException($"Product detail with id {id} not found.");
        }
        _mapper.Map(productDetailRequest, productDetailRequest);
        _context.SaveChanges();
    }

    public List<ProductDetailResponse> getProductDetailByProductId(int productId)
    {
        var productDetails = _productDetailRepository.GetProductDetailByProductId(productId);
        return _mapper.Map<List<ProductDetailResponse>>(productDetails);
    }
}