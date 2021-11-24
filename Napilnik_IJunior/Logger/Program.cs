
namespace Napilnik.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = new FileLogWritter();
            ILogger consoleLogger = new ConsoleLogWritter();
            ILogger fileSecureLogger = new SecureLogWriter(new FileLogWritter());
            ILogger consoleSecureLogger = new SecureLogWriter(new ConsoleLogWritter());
            ILogger multiLogger = LogChain.Create(new ConsoleLogWritter(), new SecureLogWriter(new FileLogWritter()));
        }
    }
}
