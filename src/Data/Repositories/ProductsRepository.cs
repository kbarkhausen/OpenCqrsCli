using System.Collections.Generic;
using System.Linq;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Data;
using OpenCqrsCli.Models;

namespace OpenCqrsCli.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        public ILogger _logger;
        private readonly ProductCatalogContext _dbContext;

        public ProductsRepository(
            ILoggerFactory loggerFactory,
            ProductCatalogContext dbContext)
        {
            _logger = loggerFactory.GetLogger(this);
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetQuery()
        {
            _logger.Trace("Getting IQueryable<Product>");
            return _dbContext.Products.AsQueryable();
        }

        public IEnumerable<Product> GetAll()
        {
            _logger.Trace("Getting all Products.");
            return _dbContext.Products.ToList();
        }

        public Product Get(int id)
        {
            _logger.Trace("Getting product with Id = " + id);
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public Product Add(Product item)
        {
            _logger.Trace("Adding 1 Product.");
            _dbContext.Products.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Update(Product item)
        {
            _logger.Trace("Updating 1 Product.");
            var product = _dbContext.Products.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
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
            var product = _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
