using System;
using System.Collections.Generic;

namespace Napilnik.Logger
{
    class LogChain : ILogger
    {
        private IEnumerable<ILogger> _loggers;

        public LogChain(IEnumerable<ILogger> loggers)
        {
            if (loggers == null)
                throw new ArgumentNullException(nameof(loggers));

            _loggers = loggers;
        }

        public void WriteError(string message)
        {
            foreach (var logger in _loggers)
                logger.WriteError(message);
        }

        public static LogChain Create(params ILogger[] loggers)
        {
            return new LogChain(loggers);
        }
    }

}
