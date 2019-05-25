using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Smarts.Core.Tests
{
    public class SemaphoreExtensionTests
    {
        [Test]
        public async Task AutomaticallyReleaseASemaphore()
        {
            var semaphore = new SemaphoreSlim(1);
            using (await semaphore.AcquireAsync())
            {
                Assert.That(semaphore.CurrentCount, Is.EqualTo(0));
            }
            Assert.That(semaphore.CurrentCount, Is.EqualTo(1));
        }
    }
}