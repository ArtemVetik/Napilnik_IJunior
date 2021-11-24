using System;

namespace Napilnik.Logger
{
    class SecureLogWriter : ILogger
    {
        private readonly ILogger _logger;

        public SecureLogWriter(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                _logger.WriteError(message);
        }
    }
}
