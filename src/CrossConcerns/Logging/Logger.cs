using System;

namespace OpenCqrsCli.CrossConcerns.Logging
{
    public class Logger : ILogger
    {
        private string _source;

        public Logger(string source)
        {
            _source = source;
        }

        public string LogName => _source;

        public void Debug(string message)
        {
            WriteToConsole(LogLevel.Debug, message);
        }

        public void Error(string message)
        {
            WriteToConsole(LogLevel.Error, message);
        }

        public void Error(string message, Exception exception)
        {
            WriteToConsole(LogLevel.Error, message + " " + exception.Message); 
        }

        public void Error(Exception exception)
        {
            WriteToConsole(LogLevel.Error, exception.Message);
        }

        public void Info(string message)
        {
            WriteToConsole(LogLevel.Info, message);
        }

        public void Trace(string message)
        {
            WriteToConsole(LogLevel.Trace, message);
        }

        private void WriteToConsole(LogLevel loglevel, string message)
        {
            var output = string.Format("{0} : {1} : {2} : {3}", DateTime.Now.ToShortTimeString(), loglevel.ToString().PadRight(5, ' '), message, LogName);
            Console.WriteLine(output);
        }
    }

    public enum LogLevel
    {
        Trace, 
        Debug,
        Info,
        Warning,
        Error
    }
}
