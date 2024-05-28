// File: Logger.cs

namespace Catalog.Tests.Utilities
{
    public static class Logger
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public static void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}