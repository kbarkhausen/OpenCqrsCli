using System.Collections.Generic;
using System.Linq;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Data;
using OpenCqrsCli.Models;

namespace OpenCqrsCli.Repositories
{
    public class ProductCatalogsRepository : IRepository<ProductCatalog>
    {
        public ILogger _logger;
        private readonly ProductCatalogContext _dbContext;

        public ProductCatalogsRepository(
            ILoggerFactory loggerFactory,
            ProductCatalogContext dbContext)
        {
            _logger = loggerFactory.GetLogger(this);
            _dbContext = dbContext;
        }

        public IQueryable<ProductCatalog> GetQuery()
        {
            _logger.Trace("Getting IQueryable<Product>");
            return _dbContext.ProductCatalogs.AsQueryable();
        }

        public IEnumerable<ProductCatalog> GetAll()
        {
            _logger.Trace("Getting all Products.");
            return _dbContext.ProductCatalogs.ToList();
        }

        public ProductCatalog Get(int id)
        {
            _logger.Trace("Getting product with Id = " + id);
            return _dbContext.ProductCatalogs.Where(x => x.ProductCatalogId == id).FirstOrDefault();
        }

        public ProductCatalog Add(ProductCatalog item)
        {
            _logger.Trace("Adding 1 Product.");
            _dbContext.ProductCatalogs.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Update(ProductCatalog item)
        {
            _logger.Trace("Updating 1 Product.");
            var savedItem = _dbContext.ProductCatalogs.Where(x => x.ProductCatalogId == item.ProductCatalogId).FirstOrDefault();
            if (savedItem != null)
            {
                savedItem.Name = item.Name;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            _logger.Trace("Deleting 1 Widget.");
            var savedItem = _dbContext.ProductCatalogs.Where(x => x.ProductCatalogId == id).FirstOrDefault();
            if (savedItem != null)
            {
                _dbContext.ProductCatalogs.Remove(savedItem);
                _dbContext.SaveChanges();
            }
        }
    }
}
