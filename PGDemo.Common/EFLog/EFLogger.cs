using Microsoft.Extensions.Logging;
using System;

namespace PGDemo.Common.EFLog
{
    public class EFLogger : ILogger
    {
        private readonly string _categoryName;

        public EFLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_categoryName.Equals("Microsoft.EntityFrameworkCore.Database.Command"))
            {
                var logContext = formatter(state, exception);
                Console.WriteLine(logContext);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
