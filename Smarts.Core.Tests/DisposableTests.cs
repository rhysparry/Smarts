using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Smarts.Core.Tests
{
    public class DisposableTests
    {
        [Test]
        public void EmptyDisposable()
        {
            using (new Disposable())
            {
                // Don't do anything
            }
        }

        [Test]
        public void DisposeAnAction()
        {
            var lst = new List<string>();
            using (new Disposable(() => lst.Add("Foo")))
            {
                Assert.That(lst, Is.Empty);
            }

            Assert.That(lst, Is.Not.Empty);
            Assert.That(lst.Count, Is.EqualTo(1));
            Assert.That(lst[0], Is.EqualTo("Foo"));
        }

        [Test]
        public void DisposingMultipleActions()
        {
            var lst = new List<string>();
            using (var d = new Disposable(() => lst.Add("Foo")))
            {
                d.Add(() => lst.Add("Bar"));
                d.Add(() => lst.Add("Baz"));
            }

            Assert.That(lst.Count, Is.EqualTo(3));
            Assert.That(lst[0], Is.EqualTo("Baz"));
            Assert.That(lst[1], Is.EqualTo("Bar"));
            Assert.That(lst[2], Is.EqualTo("Foo"));
        }

        [Test]
        public void DisposingADisposable()
        {
            var lst = new List<string>();
            var d = new Disposable(() => lst.Add("Foo"));
            using (new Disposable(d))
            {
                Assert.That(lst, Is.Empty);
            }

            Assert.That(lst.Count, Is.EqualTo(1));
            Assert.That(lst[0], Is.EqualTo("Foo"));
        }

        [Test]
        public void DisposingContinuesPastExceptions()
        {
            var lst = new List<string>();
            Assert.That(() =>
                {
                    using (var d = new Disposable(() => lst.Add("Foo")))
                    {
                        d.Add(() => throw new Exception("Bar"));
                    }
                },
                Throws.TypeOf<AggregateException>().With.InnerException.Message.EqualTo("Bar").And
                    .Property("InnerExceptions").Count.EqualTo(1));
            Assert.That(lst.Count, Is.EqualTo(1));
            Assert.That(lst[0], Is.EqualTo("Foo"));
        }

        [Test]
        public void DisposeOnlyOnce()
        {
            var lst = new List<string>();
            var d = new Disposable(() => lst.Add("Foo")) as IDisposable;
            d.Dispose();
            Assert.That(lst.Count, Is.EqualTo(1));
            Assert.That(lst[0], Is.EqualTo("Foo"));
            d.Dispose();
            Assert.That(lst.Count, Is.EqualTo(1));
        }

        [Test]
        public void InvalidOperationToAddWhenAlreadyDisposed()
        {
            var d = new Disposable();
            ((IDisposable) d).Dispose();
            Assert.That(() => d.Add(Functions.NoOp), Throws.TypeOf<ObjectDisposedException>());
        }
    }
}