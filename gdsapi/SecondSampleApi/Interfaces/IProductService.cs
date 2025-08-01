using SecondSampleApi.DTOs.Request;
using SecondSampleApi.DTOs.Response;

namespace SecondSampleApi.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetProducts(string? parameter);
        Task<ProductResponseDto?> GetProductById(int id);
        Task<ProductResponseDto> CreateProduct(ProductRequestDto request);
        Task<ProductResponseDto> UpdateProduct(int id, ProductRequestDto request);
        Task<bool> DeleteProduct(int id);
    }
} 