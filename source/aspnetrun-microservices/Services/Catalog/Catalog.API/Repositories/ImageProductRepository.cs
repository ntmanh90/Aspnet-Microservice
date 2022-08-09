using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ImageProductRepository : IImageProductRepository
    {
        private readonly ICatalogContext _context;
        private readonly ILogger<ImageProductRepository> _logger;

        public ImageProductRepository(ICatalogContext context, ILogger<ImageProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ImageProduct>> GetImageProducts()
        {

            throw new System.NotImplementedException();
        }

        public Task<ImageProduct> GetImageProductByIdd()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ImageProduct>> GetImageProductByName()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ImageProduct>> GetImageProductsByNameProduct()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateImageProduct()
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> UpdateImageProduct(ImageProduct imageProduct)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> DeleteImageProduct(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
