using Catalog.API.Entities;
using System.Collections.Generic;

namespace Catalog.API.ViewModels
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public IEnumerable<ImageProduct> Images { get; set; }
    }
}
