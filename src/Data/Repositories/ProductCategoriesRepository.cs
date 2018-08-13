using System.Collections.Generic;
using System.Linq;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Data;
using OpenCqrsCli.Models;

namespace OpenCqrsCli.Repositories
{
    public class ProductCategoriesRepository : IRepository<ProductCategory>
    {
        public ILogger _logger;
        private readonly ProductCatalogContext _dbContext;

        public ProductCategoriesRepository(
            ILoggerFactory loggerFactory,
            ProductCatalogContext dbContext)
        {
            _logger = loggerFactory.GetLogger(this);
            _dbContext = dbContext;
        }

        public IQueryable<ProductCategory> GetQuery()
        {
            _logger.Trace("Getting IQueryable<Product>");
            return _dbContext.ProductCategories.AsQueryable();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            _logger.Trace("Getting all Products.");
            return _dbContext.ProductCategories.ToList();
        }

        public ProductCategory Get(int id)
        {
            _logger.Trace("Getting product with Id = " + id);
            return _dbContext.ProductCategories.Where(x => x.ProductCategoryId == id).FirstOrDefault();
        }

        public ProductCategory Add(ProductCategory item)
        {
            _logger.Trace("Adding 1 Product.");
            _dbContext.ProductCategories.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Update(ProductCategory item)
        {
            _logger.Trace("Updating 1 Product.");
            var product = _dbContext.ProductCategories.Where(x => x.ProductCategoryId == item.ProductCategoryId).FirstOrDefault();
            if (product != null)
            {
                product.Name = item.Name;
                product.ProductCategoryId = item.ProductCategoryId;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            _logger.Trace("Deleting 1 Widget.");
            var product = _dbContext.ProductCategories.Where(x => x.ProductCategoryId == id).FirstOrDefault();
            if (product != null)
            {
                _dbContext.ProductCategories.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
