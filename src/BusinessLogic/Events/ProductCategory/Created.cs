using OpenCqrs.Events;

namespace OpenCqrsCli.Events.ProductCategory
{
    public class CreatedEvent : IEvent
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
    }
}
