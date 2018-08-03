using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OpenCqrsCli.Mappings;
using System;

namespace OpenCqrsCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start.");

            try
            {
                // create service collection
                var serviceCollection = new ServiceCollection();

                Startup.ConfigureServices(serviceCollection);

                var containerBuilder = new ContainerBuilder();

                // Once you've registered everything in the ServiceCollection, call
                // Populate to bring those registrations into Autofac. This is
                // just like a foreach over the list of things in the collection
                // to add them to Autofac.
                containerBuilder.Populate(serviceCollection);

                // Make your Autofac registrations. Order is important!
                // If you make them BEFORE you call Populate, then the
                // registrations in the ServiceCollection will override Autofac
                // registrations; if you make them AFTER Populate, the Autofac
                // registrations will override. You can make registrations
                // before or after Populate, however you choose.
                //containerBuilder.RegisterType<MessageHandler>().As<IHandler>();

                // Creating a new AutofacServiceProvider makes the container
                // available to your app using the Microsoft IServiceProvider
                // interface so you can use those abstractions rather than
                // binding directly to Autofac.
                var container = containerBuilder.Build();
                var serviceProvider = new AutofacServiceProvider(container);

                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMissingTypeMaps = true;
                    cfg.AllowNullDestinationValues = true;

                    cfg.CreateMyMappings();
                });

                // entry to run app
                serviceProvider.GetService<App>().Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Program end.");
            Console.ReadKey();
        }
    }
}
