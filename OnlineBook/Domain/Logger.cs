using System;

namespace OnlineBook.Domain
{
    public class Logger :ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}
