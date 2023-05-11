using BLL.Entities;
using BLL.Mappers;
using BLL.Repositories;
using IDalProductRepository = DAL.Repositories.IProductRepository;
using DalProduct = DAL.Entities.Product;


namespace BLL.Services
{
    public class ProductService : IProductRepository
    {
        private readonly IDalProductRepository _repository;

        public ProductService(IDalProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Get()
        {
            return _repository.Get().Select(p => p.ToBll());
        }

        public Product? Get(int id)
        {
            return _repository.Get(id)?.ToBll();
        }

        public Product Insert(Product product)
        {
            return _repository.Insert(product.ToDal()).ToBll();
        }

        public bool Update(Product product)
        {
            DalProduct p = product.ToDal();
            return _repository.Update(p);
        }
        
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
