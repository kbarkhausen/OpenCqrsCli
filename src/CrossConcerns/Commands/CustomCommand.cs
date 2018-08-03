using OpenCqrs.Commands;

namespace OpenCqrsCli.CrossConcerns.Commands
{
    public class CustomCommand<T1, T2> : Command
    {
        public T1 PreExecutionEvent;
        public T2 PostExecutionEvent;
    }
}
