using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Interfaces
{
    public interface IMyShopClient
    {
        Task AddProduct(Product product);
        Task DeleteProduct(long id);
        Task<Product> GetProduct(Guid id);
        Task<List<Product>> GetProducts();
        Task UpdateProduct(Product product, long id);
    }
}