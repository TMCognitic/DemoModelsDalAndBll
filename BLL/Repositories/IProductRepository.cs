using BLL.Entities;

namespace BLL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product? Get(int id);
        Product Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
