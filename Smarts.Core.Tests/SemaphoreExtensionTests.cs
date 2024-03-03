using System.Threading;
using System.Threading.Tasks;

namespace Smarts.Core.Tests;

public class SemaphoreExtensionTests
{
    [Fact]
    public async Task AutomaticallyReleaseASemaphore()
    {
        var semaphore = new SemaphoreSlim(1);
        using (await semaphore.AcquireAsync())
        {
            Assert.Equal(0, semaphore.CurrentCount);
        }
        Assert.Equal(1, semaphore.CurrentCount);
    }
}