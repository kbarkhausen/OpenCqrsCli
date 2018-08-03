using System.Threading.Tasks;
using OpenCqrs.Events;
using OpenCqrsCli.CrossConcerns.Logging;

namespace OpenCqrsCli.Handlers.Events.Product.CreatedEventHandlers
{
    public class UpdateProductCatalog : IEventHandlerAsync<OpenCqrsCli.Events.Product.CreatedEvent>
    {
        private ILogger _logger;

        public UpdateProductCatalog(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(this);
        }

        public Task HandleAsync(OpenCqrsCli.Events.Product.CreatedEvent @event)
        {
            _logger.Info("Updating product catalog calculated totals.");

            return Task.CompletedTask;
        }
    }
}
