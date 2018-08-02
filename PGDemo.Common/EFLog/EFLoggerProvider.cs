using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace PGDemo.Common.EFLog
{
    public class EFLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EFLogger(categoryName);
        }
    }
}
