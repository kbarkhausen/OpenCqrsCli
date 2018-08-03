using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCqrsCli.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public int ProductCatalogId { get; set; }

        [ForeignKey("ProductCatalogId")]
        public ProductCatalog ProductCatalog { get; set; }

        public List<Product> Products { get; set; }
    }
}
