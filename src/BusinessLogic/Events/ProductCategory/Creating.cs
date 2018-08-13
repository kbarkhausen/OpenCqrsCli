using OpenCqrs.Events;
using System;

namespace OpenCqrsCli.Events.ProductCategory
{
    public class CreatingEvent : IEvent
    {
        public string Name { get; set; }

        public int ProductCatalogId { get; set; }
    }
}
