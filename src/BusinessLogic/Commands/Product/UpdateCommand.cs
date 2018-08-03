using OpenCqrsCli.CrossConcerns.Commands;

namespace OpenCqrsCli.Commands.Product
{
    public class UpdateCommand : CustomCommand<Events.Product.UpdatingEvent, Events.Product.UpdatedEvent>
    {
    }
}
