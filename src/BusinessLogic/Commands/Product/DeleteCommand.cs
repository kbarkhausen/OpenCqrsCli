using OpenCqrsCli.CrossConcerns.Commands;

namespace OpenCqrsCli.Commands.Product
{
    public class DeleteCommand : CustomCommand<Events.Product.DeletingEvent, Events.Product.DeletedEvent>
    {
    }
}
