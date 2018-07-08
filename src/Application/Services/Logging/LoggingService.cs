using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.Logging
{
    public class LoggingService :IDisposable
    {
        private readonly ILogger _logger;
        public LoggingService(ILogger logger)
        {
            _logger = logger;
        }

        public void TryLogging(string message)
        {
            _logger.Error(message);
        }


        public void Dispose()
        {
            //
        }
    }
}
