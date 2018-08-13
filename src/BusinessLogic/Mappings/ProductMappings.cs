using AutoMapper;

namespace OpenCqrsCli.Mappings
{
    public static class IMapperConfigurationExpressionExtensions
    {
        public static void CreateMyMappings(this IMapperConfigurationExpression _config)
        {
            _config.CreateMap<Commands.Product.CreateCommand, Models.Product>();
            _config.CreateMap<Models.Product, Events.Product.CreatedEvent>();

            _config.CreateMap<Commands.ProductCatalog.CreateCommand, Models.ProductCatalog>();
            _config.CreateMap<Models.ProductCatalog, Events.ProductCatalog.CreatedEvent>();

            _config.CreateMap<Commands.ProductCategory.CreateCommand, Models.ProductCategory>();
            _config.CreateMap<Models.ProductCategory, Events.ProductCategory.CreatedEvent>();
        }
    }
}
