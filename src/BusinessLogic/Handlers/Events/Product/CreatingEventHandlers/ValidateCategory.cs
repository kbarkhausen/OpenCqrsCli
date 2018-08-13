using OpenCqrs.Events;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Events.Product;
using OpenCqrsCli.Repositories;
using System;

namespace OpenCqrsCli.Handlers.Events.Product.CreatingEventHandlers
{
    public class ValidateCategory : IEventHandler<CreatingEvent>
    {
        private ILogger _logger;
        private IRepository<Models.ProductCategory> _repository;

        public ValidateCategory(
            ILoggerFactory loggerFactory,
            IRepository<Models.ProductCategory> repository)
        {
            _logger = loggerFactory.GetLogger(this);
            _repository = repository;
        }

        public void Handle(CreatingEvent @event)
        {
            if (@event.ProductCategoryId == 0)
                throw new Exception("Product category Id cannot be blank!");

            var category = _repository.Get(@event.ProductCategoryId);

            if (category == null)
                throw new Exception("Product category not found!");

            _logger.Info("The category for the new product is valid.");
        }
    }
}
