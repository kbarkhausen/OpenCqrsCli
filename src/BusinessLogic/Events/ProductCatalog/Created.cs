using OpenCqrs.Events;

namespace OpenCqrsCli.Events.ProductCatalog
{
    public class CreatedEvent : IEvent
    {
        public int ProductCatalogId { get; set; }
        public string Name { get; set; }
    }
}
