using OpenCqrs.Events;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Events.Product;
using System;

namespace OpenCqrsCli.Tests.Handlers.Events.Product.CreatingEventHandlers
{
    public class ValidateName : IEventHandler<CreatingEvent>
    {
        private ILogger _logger;

        public ValidateName(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(this);
        }

        public void Handle(CreatingEvent @event)
        {
            if (@event.Name == null || @event.Name.Trim().Length <= 0)
                throw new Exception("The name of the new product cannot be empty or null.");

            _logger.Info("The name for the new product is valid.");
        }
    }
}
