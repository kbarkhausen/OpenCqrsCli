using OpenCqrs.Events;
using System;

namespace OpenCqrsCli.Events.ProductCatalog
{
    public class CreatingEvent : IEvent
    {
        public string Name { get; set; }

    }
}
