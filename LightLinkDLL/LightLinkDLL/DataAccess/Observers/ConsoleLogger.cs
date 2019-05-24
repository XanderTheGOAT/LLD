using System;

namespace LightLinkDLL.DataAccess
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(object value)
        {
            Console.WriteLine(value);
        }

        public void LogError(Exception error)
        {
            var defaultBackground = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(error.ToString());
            Console.BackgroundColor = defaultBackground;
        }
    }
}