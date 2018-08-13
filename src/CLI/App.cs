using OpenCqrs;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Data;
using OpenCqrsCli.Models;
using OpenCqrsCli.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCqrsCli
{
    public class App
    {
        private readonly ILogger _logger;
        private readonly IDispatcher _dispatcher;
        private readonly IRepository<Product> _products;

        public App(
            ILoggerFactory loggerFactory,
            IDispatcher dispatcher,
            IRepository<Product> products)
        {
            _logger = loggerFactory.GetLogger(this);
            _dispatcher = dispatcher;
            _products = products;
        }

        public async void Run()
        {
            _logger.Info("Program run started!");

            Commands.ProductCatalog.CreateCommand newProductCatalogCommand;

            newProductCatalogCommand = new Commands.ProductCatalog.CreateCommand
            {
                Name = "catalog1",
            };

            await _dispatcher.SendAndPublishAsync(newProductCatalogCommand);

            int newCatalogId = newProductCatalogCommand.PostExecutionEvent.ProductCatalogId;

            Commands.ProductCategory.CreateCommand newProductCategoryCommand;

            newProductCategoryCommand = new Commands.ProductCategory.CreateCommand
            {
                Name = "category1",
                ProductCatalogId = newCatalogId
            };

            await _dispatcher.SendAndPublishAsync(newProductCategoryCommand);

            int newCategoryId = newProductCategoryCommand.PostExecutionEvent.ProductCategoryId;

            Commands.Product.CreateCommand newProductCommand;

            newProductCommand = new Commands.Product.CreateCommand
            {
                Name = "product1",
                ProductCategoryId = newCategoryId
            };
           
            await _dispatcher.SendAndPublishAsync(newProductCommand);

            newProductCommand = new Commands.Product.CreateCommand
            {
                Name = null,
                ProductCategoryId = newCategoryId
            };

            await _dispatcher.SendAndPublishAsync(newProductCommand);

            var products = _products.GetAll();
            if (products != null && products.Any())
            {
                _logger.Info(string.Format("Found {0} items.", products.Count()));
                foreach (var item in products)
                {
                    _logger.Info(string.Format("Product: ID={0}, Name={1}", item.ProductId, item.Name));
                }
            }          

             _logger.Info("Program run completed successfully!");

            var allProducts = _products.GetAll();

            _logger.Info(string.Format("Found {0} products saved on the database.", allProducts.Count()));

            await Task.CompletedTask;
        }
    }
}
