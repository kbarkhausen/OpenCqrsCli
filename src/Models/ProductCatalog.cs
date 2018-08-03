using System;
using System.Collections.Generic;

namespace OpenCqrsCli.Models
{
    public class ProductCatalog
    {
        public int ProductCatalogId { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
