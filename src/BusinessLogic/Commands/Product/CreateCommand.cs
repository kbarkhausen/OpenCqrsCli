using OpenCqrsCli.CrossConcerns.Commands;
using System;

namespace OpenCqrsCli.Commands.Product
{
    public class CreateCommand : CustomCommand<Events.Product.CreatingEvent, Events.Product.CreatedEvent>
    {
        public string Name { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
