using NUnit.Framework;

namespace Smarts.Core.Tests
{
    public class FunctionTests
    {
        [Test]
        public void CallNoOp()
        {
            Functions.NoOp();
        }
    }
}