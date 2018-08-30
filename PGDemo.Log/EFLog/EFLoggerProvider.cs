using Microsoft.Extensions.Logging;

namespace PGDemo.Log.EFLog
{
    public class EFLoggerProvider : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new EFLogger(categoryName);
        }

        /// <summary>
        /// There is no resource to release.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
