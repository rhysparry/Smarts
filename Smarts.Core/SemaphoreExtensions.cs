using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smarts.Core
{
    public static class SemaphoreExtensions
    {
        public static async Task<IDisposable> AcquireAsync(this SemaphoreSlim semaphore)
        {
            await semaphore.WaitAsync();
            return new Disposable(() => semaphore.Release());
        }
    }
}