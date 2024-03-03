using System;

namespace Smarts.Core.Tests;

public class ConsoleTests
{
    [SkippableFact]
    public void SetForegroundAndReset()
    {
        Skip.If(Console.IsOutputRedirected);
        var originalForeground = Console.ForegroundColor;
        var originalBackground = Console.BackgroundColor;
        Skip.If(originalBackground == originalForeground);
        using (originalBackground.AsForeground())
        {
            Assert.Equal(originalBackground, Console.ForegroundColor);
            Assert.Equal(originalBackground, Console.BackgroundColor);
        }

        Assert.Equal(originalForeground, Console.ForegroundColor);
        Assert.Equal(originalBackground, Console.BackgroundColor);
    }

    [SkippableFact]
    public void SetBackgroundAndReset()
    {
        Skip.If(Console.IsOutputRedirected);
        var originalForeground = Console.ForegroundColor;
        var originalBackground = Console.BackgroundColor;
        Skip.If(originalBackground == originalForeground);
        using (originalForeground.AsBackground())
        {
            Assert.Equal(originalForeground, Console.BackgroundColor);
            Assert.Equal(originalForeground, Console.ForegroundColor);
        }

        Assert.Equal(originalForeground, Console.ForegroundColor);
        Assert.Equal(originalBackground, Console.BackgroundColor);
    }
}