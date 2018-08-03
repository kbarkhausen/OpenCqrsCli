using OpenCqrs.Events;

namespace OpenCqrsCli.Events.Product
{
    public class CreatedEvent : IEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
