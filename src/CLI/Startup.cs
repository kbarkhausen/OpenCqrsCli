using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenCqrs.Bus.ServiceBus.Extensions;
using OpenCqrs.Dependencies;
using OpenCqrs.Extensions;
using OpenCqrs.Store.EF.SqlServer;
using OpenCqrsCli.CrossConcerns.DI;
using OpenCqrsCli.CrossConcerns.PropertyMappings;
using OpenCqrsCli.Data;
using OpenCqrsCli.Mappings;

namespace OpenCqrsCli
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Adding JSON file into IConfiguration.
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            // Register IConfiguration as a singleton
            services.AddSingleton(config);

            services.AddDbContext<ProductCatalogContext>(options => options.UseInMemoryDatabase("ProductCatalogDb"));

            //var connString = config.GetConnectionString("ProductCatalogDB");
            //services.AddDbContext<ProductCatalogContext>(options => options.UseSqlServer(connString));

            services.AddOptions();

            services
                .AddOpenCqrs(typeof(Commands.Product.CreateCommand)) // <- Register all OpenCQRS commands, events and handlers
                .AddSqlServerProvider(config)
                .AddServiceBusProvider(config);

            services.AddTransient<CrossConcerns.Logging.ILoggerFactory, CrossConcerns.Logging.LoggerFactory>();

            // Override the OpenCqrs resolver that uses the HttpContext
            // with a custom resolver that uses Net Core IServiceProvider
            services.AddScoped<IResolver, CustomResolver>();        

            // Add services and repositories
            services.AddTransient<Repositories.IRepository<Models.Product>, OpenCqrsCli.Repositories.ProductsRepository>();
            
            // add app
            services.AddTransient<App>();
        }
    }
}
