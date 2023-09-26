using System;

namespace BookstoreInventoryApp.Domain
{
    public class Logger :ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}
