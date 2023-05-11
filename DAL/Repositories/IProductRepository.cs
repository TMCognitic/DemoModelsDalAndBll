using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
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
