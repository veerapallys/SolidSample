using System;

namespace ArdalisRating{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
           Console.WriteLine(message);
        }
    }
}