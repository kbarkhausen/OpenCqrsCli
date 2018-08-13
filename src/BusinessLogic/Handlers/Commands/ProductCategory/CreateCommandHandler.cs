using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OpenCqrs;
using OpenCqrs.Commands;
using OpenCqrs.Events;
using OpenCqrsCli.Commands.ProductCategory;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Repositories;

namespace OpenCqrsCli.Handlers.Commands.ProductCategory
{
    public class CreateCommandHandler : ICommandHandlerWithEventsAsync<CreateCommand>
    {
        private ILogger _logger;
        private IDispatcher _dispatcher;
        private IRepository<Models.ProductCategory> _repository;
        private List<IEvent> PostEvents = new List<IEvent>();

        public CreateCommandHandler(
            ILoggerFactory loggerFactory,
            IDispatcher dispatcher,
            IRepository<Models.ProductCategory> repository)
        {
            _logger = loggerFactory.GetLogger(this);
            _dispatcher = dispatcher;
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> HandleAsync(CreateCommand command)
        {

            _logger.Info("Started adding a new product category to the catalog");

            try
            {
                _dispatcher.Publish(Mapper.Map<OpenCqrsCli.Events.ProductCategory.CreatingEvent>(command));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new List<Event>();                
            }

            await Task.CompletedTask;

            var entity = Mapper.Map<OpenCqrsCli.Models.ProductCategory>(command);

            _repository.Add(entity);
         
            command.PostExecutionEvent = Mapper.Map<OpenCqrsCli.Events.ProductCategory.CreatedEvent>(entity);

            PostEvents.Add(command.PostExecutionEvent);

            _logger.Info("Completed adding a new product category to the catalog");

            return PostEvents;
        }
    }
}
