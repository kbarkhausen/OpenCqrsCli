using OpenCqrs.Events;
using OpenCqrsCli.CrossConcerns.Logging;
using System;

namespace OpenCqrsCli.Events.Product.CreatingEventHandlers
{
    public class ValidateCategory : IEventHandler<CreatingEvent>
    {
        private ILogger _logger;

        public ValidateCategory(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(this);
        }

        public void Handle(CreatingEvent @event)
        {
            if (@event.ProductCategoryId == null)
                throw new Exception("Product category cannot be blank!");

            _logger.Info("The category for the new product is valid.");
        }
    }
}
