using OpenCqrs.Events;
using OpenCqrsCli.CrossConcerns.Logging;
using System.Threading.Tasks;

namespace OpenCqrsCli.Handlers.Events.Product.CreatedEventHandlers
{
    public class NotifyUsers : IEventHandlerAsync<OpenCqrsCli.Events.Product.CreatedEvent>
    {
        private ILogger _logger;

        public NotifyUsers(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(this);
        }

        public Task HandleAsync(OpenCqrsCli.Events.Product.CreatedEvent @event)
        {
            _logger.Info("Notifying customers of the new Product added");

            return Task.CompletedTask;
        }
    }
}
