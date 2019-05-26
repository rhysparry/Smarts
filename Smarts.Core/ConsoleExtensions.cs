using System;

namespace Smarts.Core
{
    public static class ConsoleExtensions
    {
        public static IDisposable AsForeground(this ConsoleColor color)
        {
            var currentForeground = Console.ForegroundColor;
            Console.ForegroundColor = color;
            return new Disposable(() => Console.ForegroundColor = currentForeground);
        }

        public static IDisposable AsBackground(this ConsoleColor color)
        {
            var currentBackground = Console.BackgroundColor;
            Console.BackgroundColor = color;
            return new Disposable(() => Console.BackgroundColor = currentBackground);
        }
    }
}