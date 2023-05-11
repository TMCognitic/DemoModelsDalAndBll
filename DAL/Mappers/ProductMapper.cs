using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static partial class Mapper
    {
        internal static Product ToProduct(this IDataRecord record)
        {
            return new Product
            {
                Id = (int)record["Id"],
                Name = (string)record["Nom"],
                Price = (double)record["Prix"]
            };
        }
    }
}
