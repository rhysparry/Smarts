using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Smarts.Core.Tests
{
    public class CollectionExtensionTests
    {
        [Test]
        public void AddRangeAddsValuesToAHashSet()
        {
            var values = new HashSet<int> {10, 11, 12, 13};
            values.AddRange(Enumerable.Range(1, 10));
            Assert.That(values, Has.Exactly(13).Items.InRange(1, 13));
        }

        [Test]
        public void AddRangeStillWorksWithList()
        {
            var values = new List<int>();
            values.AddRange(Enumerable.Range(1, 10));
            Assert.That(values, Has.Exactly(10).Items.InRange(1, 10));
        }
    }
}