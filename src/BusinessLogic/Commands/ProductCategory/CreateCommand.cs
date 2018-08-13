using OpenCqrsCli.CrossConcerns.Commands;
using System;

namespace OpenCqrsCli.Commands.ProductCategory
{
    public class CreateCommand : CustomCommand<Events.ProductCategory.CreatingEvent, Events.ProductCategory.CreatedEvent>
    {
        public string Name { get; set; }
        public int ProductCatalogId { get; set; }
    }
}
