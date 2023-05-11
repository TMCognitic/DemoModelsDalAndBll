using BLL.Entities;
using DalProduct = DAL.Entities.Product;

namespace BLL.Mappers
{
    internal static partial class Mapper
    {
        internal static Product ToBll(this DalProduct entity)
        {
            return new Product(entity.Id, entity.Name, entity.Price);
        }

        internal static DalProduct ToDal(this Product entity)
        {
            return new DalProduct() { Id = entity.Id, Name = entity.Name, Price = entity.Price };
        }
    }
}
