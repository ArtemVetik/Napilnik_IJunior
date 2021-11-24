using System;

namespace Napilnik.Logger
{
    class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }

        public void Find()
        {
            _logger.WriteError("Error");
        }
    }
}
