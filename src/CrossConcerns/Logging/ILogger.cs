using System;

namespace OpenCqrsCli.CrossConcerns.Logging
{
    public interface ILogger
    {
        string LogName { get; }

        void Info(string message);
        void Debug(string message);
        void Trace(string message);
        void Error(string message);
        void Error(string message, Exception exception);
        void Error(Exception exception);
    }
}
