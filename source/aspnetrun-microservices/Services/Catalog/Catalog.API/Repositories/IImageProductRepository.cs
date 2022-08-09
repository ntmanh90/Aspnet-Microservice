using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IImageProductRepository
    {
        Task<IEnumerable<ImageProduct>> GetImageProducts();
        Task<IEnumerable<ImageProduct>> GetImageProductsByNameProduct();
        Task<IEnumerable<ImageProduct>> GetImageProductByName();
        Task<ImageProduct> GetImageProductByIdd();

        Task CreateImageProduct();

        Task<bool> UpdateImageProduct(ImageProduct imageProduct);
        Task<bool> DeleteImageProduct(string id);



    }
}
