using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Eq("name", "IPhone X") & builder.Eq("name", "Samsung 10");
            var check = await _context.Products.Find(filter).ToListAsync();

            var query = _context.Products.AsQueryable().Where(a => a.Name == "IPhone X" || a.Name == "Samsung 10").ToList();

            var sortDown = await _context.Products.CountDocumentsAsync(a => a.Price > 0);

            var filter01 = new BsonDocument();
            var check_filter01 = await _context.Products.Find(filter01).ToListAsync();

            var marth = _context.Products.Aggregate().Match(a => a.Price > 0).ToListAsync();
            var group = _context.Products.Aggregate().Group(a => a.Name, g => new { Name = g.ToList() }).ToList();



            return check;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var builder = Builders<ImageProduct>.Filter;
            var filter = builder.Eq("cuisine", "Italian") & builder.Eq("address.zipcode", "10075");

            var result = await _context.ImageProducts.Find(filter).ToListAsync();

            return await _context.Products.Find(p => p.Category == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteRsult = await _context.Products.DeleteOneAsync(p => p.Id == id);

            return deleteRsult.IsAcknowledged && deleteRsult.DeletedCount > 0;
        }
    }
}
