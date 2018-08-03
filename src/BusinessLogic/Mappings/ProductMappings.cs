using AutoMapper;

namespace OpenCqrsCli.Mappings
{
    public static class IMapperConfigurationExpressionExtensions
    {
        public static void CreateMyMappings(this IMapperConfigurationExpression _config)
        {
            _config.CreateMap<Commands.Product.CreateCommand, Models.Product>();
            _config.CreateMap<Models.Product, Events.Product.CreatedEvent>();
        }
    }
}
