using Microsoft.Extensions.Logging;

namespace PGDemo.Common.EFLog
{
    public class EFLoggerProvider : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new EFLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}
