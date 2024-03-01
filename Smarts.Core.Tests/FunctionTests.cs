using System.Linq;
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

        [Test]
        public void IdentityOfAStruct()
        {
            const int num = 42;
            var identity = Functions.Identity(num);
            Assert.That(identity, Is.EqualTo(num));
        }

        [Test]
        public void IdentityOfAClass()
        {
            var obj = new object();
            var identity = Functions.Identity(obj);
            Assert.That(identity, Is.SameAs(obj));
        }

        [Test]
        public void IdentityUsageExample()
        {
            var fifteen = Enumerable.Range(1, 5).Select(Functions.Identity).Sum();
            Assert.That(fifteen, Is.EqualTo(15));
        }
    }
}