using DAL.Entities;
using DAL.Mappers;
using DAL.Repositories;
using System.Data;
using Tools.Database;

namespace DAL.Services
{
    public class ProductService : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Product> Get()
        {
            return _dbConnection.ExecuteReader("Select Id, Nom, Prix FROM Produit", dr => dr.ToProduct());
        }

        public Product? Get(int id)
        {
            return _dbConnection.ExecuteReader("Select Id, Nom, Prix FROM Produit WHERE Id = @Id", dr => dr.ToProduct(), parameters: new {Id = id}).SingleOrDefault();
        }

        public Product Insert(Product product)
        {
            int? id = (int?)_dbConnection.ExecuteScalar("INSERT INTO Produit (Nom, Prix) OUTPUT inserted.Id VALUES (@Nom, @Prix)", parameters: new { Nom = product.Name, Prix = product.Price });

            if (!id.HasValue)
                throw new Exception("Something wrong during insertion");

            product.Id = id.Value;

            return product;
        }

        public bool Update(Product product)
        {
            int rows = _dbConnection.ExecuteNonQuery("UPDATE Produit SET Prix = @Prix WHERE Id = @Id", parameters: new { Id = product.Id, Prix = product.Price });
            return rows == 1;
        }

        public bool Delete(int id)
        {
            int rows = _dbConnection.ExecuteNonQuery("DELETE FROM Produit WHERE Id = @Id", parameters: new { Id = id });
            return rows == 1;
        }
    }
}
