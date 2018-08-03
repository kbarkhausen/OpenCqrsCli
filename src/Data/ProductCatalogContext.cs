using Microsoft.EntityFrameworkCore;

namespace OpenCqrsCli.Data
{
    public class ProductCatalogContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductCategory> ProductCategories { get; set; }
        public DbSet<Models.ProductCatalog> ProductCatalogs { get; set; }

        public ProductCatalogContext() : base()
        {
        }

        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
          : base(options)
        {

        }
    }
}
