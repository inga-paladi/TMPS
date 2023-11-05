using System;

namespace OnlineBook.Domain
{
    public class Logger :ILogger
    {
        private static Logger instance;
        private Logger() { }
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}
