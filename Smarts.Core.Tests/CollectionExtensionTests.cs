using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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

        [Test]
        public void PadRightThrowsWhenNegativeLength()
        {
            var list = new List<int> {1, 2, 3};
            Assert.That(() => list.PadRight(-1, 4), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void PadRightPadsProperly()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(10, 2);
            Assert.That(list.Count, Is.EqualTo(10));
            Assert.That(list.Sum(), Is.EqualTo(20));
            Assert.That(list.Skip(3).Sum(), Is.EqualTo(14));
        }

        [Test]
        public void PadRightLengthAlreadyPaddedLength()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(3, 9);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list.Sum(), Is.EqualTo(6));
        }

        [Test]
        public void PadRightLengthGreaterThanPaddedLength()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            list.PadRight(3, 23);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(15));
        }

        [Test]
        public void PadRightFactoryFunctionThrowsWhenNegativeLength()
        {
            var list = new List<int> {1, 2, 3};
            Assert.That(() => list.PadRight(-1, () => 4), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void PadRightFactoryFunctionPadsProperly()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(10, () => 2);
            Assert.That(list.Count, Is.EqualTo(10));
            Assert.That(list.Sum(), Is.EqualTo(20));
            Assert.That(list.Skip(3).Sum(), Is.EqualTo(14));
        }

        [Test]
        public void PadRightFactoryFunctionLengthAlreadyPaddedLength()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(3, () => 9);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list.Sum(), Is.EqualTo(6));
        }

        [Test]
        public void PadRightFactoryFunctionLengthGreaterThanPaddedLength()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            list.PadRight(3, () => 23);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(15));
        }

        [Test]
        public void PadRightFactoryWithDefaultOffset()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(5, i => i + 1);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(9));
            Assert.That(list.Skip(3).Sum(), Is.EqualTo(3));
        }

        [Test]
        public void PadRightFactoryWithCustomOffset()
        {
            var list = new List<int> {1, 2, 3};
            list.PadRight(5, i => i + 1, 10);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(29));
            Assert.That(list.Skip(3).Sum(), Is.EqualTo(23));
        }

        [Test]
        public void PadLeftThrowsWhenNegativeLength()
        {
            var list = new List<int> {1, 2, 3};
            Assert.That(() => list.PadLeft(-1, 4), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void PadLeftPadsProperly()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(10, 2);
            Assert.That(list.Count, Is.EqualTo(10));
            Assert.That(list.Sum(), Is.EqualTo(20));
            Assert.That(list.Take(7).Sum(), Is.EqualTo(14));
        }

        [Test]
        public void PadLeftLengthAlreadyPaddedLength()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(3, 9);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list.Sum(), Is.EqualTo(6));
        }

        [Test]
        public void PadLeftLengthGreaterThanPaddedLength()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            list.PadLeft(3, 23);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(15));
        }

        [Test]
        public void PadLeftFactoryFunctionThrowsWhenNegativeLength()
        {
            var list = new List<int> {1, 2, 3};
            Assert.That(() => list.PadLeft(-1, () => 4), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void PadLeftFactoryFunctionPadsProperly()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(10, () => 2);
            Assert.That(list.Count, Is.EqualTo(10));
            Assert.That(list.Sum(), Is.EqualTo(20));
            Assert.That(list.Take(7).Sum(), Is.EqualTo(14));
        }

        [Test]
        public void PadLeftFactoryFunctionLengthAlreadyPaddedLength()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(3, () => 9);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list.Sum(), Is.EqualTo(6));
        }

        [Test]
        public void PadLeftFactoryFunctionLengthGreaterThanPaddedLength()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            list.PadLeft(3, () => 23);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(15));
        }

        [Test]
        public void PadLeftFactoryWithDefaultOffset()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(5, i => i + 1);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(9));
            Assert.That(list.Take(2).Sum(), Is.EqualTo(3));
        }

        [Test]
        public void PadLeftFactoryWithCustomOffset()
        {
            var list = new List<int> {1, 2, 3};
            list.PadLeft(5, i => i + 1, 10);
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.Sum(), Is.EqualTo(29));
            Assert.That(list.Take(2).Sum(), Is.EqualTo(23));
        }
    }
}