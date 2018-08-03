using System;

namespace OpenCqrsCli.CrossConcerns.Logging
{
    public interface ILoggerFactory
    {
        ILogger GetLogger(string name);
        ILogger GetLogger(Type source);
        ILogger GetLogger(Object source);
    }
}
