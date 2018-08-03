using OpenCqrs.Events;
using System;

namespace OpenCqrsCli.Events.Product
{
    public class CreatingEvent : IEvent
    {
        public string Name { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}
