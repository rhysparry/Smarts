using System;
using NUnit.Framework;

namespace Smarts.Core.Tests
{
    public class ConsoleTests
    {
        [Test]
        public void SetForegroundAndReset()
        {
            Assume.That(Console.IsOutputRedirected, Is.False);
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;
            Assume.That(originalBackground, Is.Not.EqualTo(originalForeground));
            using (originalBackground.AsForeground())
            {
                Assert.That(Console.ForegroundColor, Is.EqualTo(originalBackground));
                Assert.That(Console.BackgroundColor, Is.EqualTo(originalBackground));
            }

            Assert.That(Console.BackgroundColor, Is.EqualTo(originalBackground));
            Assert.That(Console.ForegroundColor, Is.EqualTo(originalForeground));
        }

        [Test]
        public void SetBackgroundAndReset()
        {
            Assume.That(Console.IsOutputRedirected, Is.False);
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;
            Assume.That(originalBackground, Is.Not.EqualTo(originalForeground));
            using (originalForeground.AsBackground())
            {
                Assert.That(Console.ForegroundColor, Is.EqualTo(originalForeground));
                Assert.That(Console.BackgroundColor, Is.EqualTo(originalForeground));
            }

            Assert.That(Console.BackgroundColor, Is.EqualTo(originalBackground));
            Assert.That(Console.ForegroundColor, Is.EqualTo(originalForeground));
        }
    }
}