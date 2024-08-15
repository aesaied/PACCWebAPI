
namespace StoreAPI.AppServices.Products
{
    public interface IProductsAppService
    {
        Task<int> Create(CreateProductDto input);
      
        Task<ProductDto?> GetById(int id);
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}