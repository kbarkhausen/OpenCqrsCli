using System;

namespace OpenCqrsCli.CrossConcerns.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger(string name)
        {
            return new Logger(name);
        }

        public ILogger GetLogger(Type source)
        {
            return new Logger(source.FullName);
        }

        public ILogger GetLogger(object source)
        {
            return new Logger(source.GetType().Name);
        }
    }
}
