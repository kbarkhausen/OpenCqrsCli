using OpenCqrsCli.CrossConcerns.Commands;
using System;

namespace OpenCqrsCli.Commands.ProductCatalog
{
    public class CreateCommand : CustomCommand<Events.ProductCatalog.CreatingEvent, Events.ProductCatalog.CreatedEvent>
    {
        public string Name { get; set; }
    }
}
