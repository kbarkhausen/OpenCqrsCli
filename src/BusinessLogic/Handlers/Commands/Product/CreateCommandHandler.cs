using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OpenCqrs;
using OpenCqrs.Commands;
using OpenCqrs.Events;
using OpenCqrsCli.Commands.Product;
using OpenCqrsCli.CrossConcerns.Logging;
using OpenCqrsCli.Repositories;

namespace OpenCqrsCli.Handlers.Commands.Product
{
    public class CreateCommandHandler : ICommandHandlerWithEventsAsync<CreateCommand>
    {
        private ILogger _logger;
        private IDispatcher _dispatcher;
        private IRepository<Models.Product> _repository;
        private List<IEvent> PostEvents = new List<IEvent>();

        public CreateCommandHandler(
            ILoggerFactory loggerFactory,
            IDispatcher dispatcher,
            IRepository<Models.Product> repository)
        {
            _logger = loggerFactory.GetLogger(this);
            _dispatcher = dispatcher;
            _repository = repository;
        }

        async Task<IEnumerable<IEvent>> ICommandHandlerWithEventsAsync<CreateCommand>.HandleAsync(CreateCommand command)
        {

            _logger.Info("Started adding a new product to the catalog");

            try
            {
                command.PreExecutionEvent = Mapper.Map<OpenCqrsCli.Events.Product.CreatingEvent>(command);
                _dispatcher.Publish(command.PreExecutionEvent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new List<Event>();                
            }

            await Task.CompletedTask;

            var entity = Mapper.Map<OpenCqrsCli.Models.Product>(command);

            _repository.Add(entity);
         
            command.PostExecutionEvent = Mapper.Map<OpenCqrsCli.Events.Product.CreatedEvent>(entity);            

            PostEvents.Add(command.PostExecutionEvent);

            _logger.Info("Completed adding a new product to the catalog");

            return PostEvents;
        }
    }
}
