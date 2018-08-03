using OpenCqrs.Dependencies;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OpenCqrsCli.CrossConcerns.Logging;

namespace OpenCqrsCli.CrossConcerns.DI
{
    public class CustomResolver : IResolver
    {
        private System.IServiceProvider _serviceProvider;
        private ILogger _logger;

        public CustomResolver(
            System.IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(this);
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            var instance = _serviceProvider.GetService<T>();
            return instance;
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            var type = typeof(T);
            var instances = _serviceProvider.GetServices<T>();
            return instances;
        }
    }
}
