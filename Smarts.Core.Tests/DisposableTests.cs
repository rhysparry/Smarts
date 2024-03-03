using System;
using System.Collections.Generic;

namespace Smarts.Core.Tests;

public class DisposableTests
{
    [Fact]
    public void EmptyDisposable()
    {
        using (new Disposable())
        {
            // Don't do anything
        }
    }

    [Fact]
    public void DisposeAnAction()
    {
        var lst = new List<string>();
        using (new Disposable(() => lst.Add("Foo")))
        {
            Assert.Empty(lst);
        }

        Assert.NotEmpty(lst);
        Assert.Single(lst);
        Assert.Equal("Foo", lst[0]);
    }

    [Fact]
    public void DisposingMultipleActions()
    {
        var lst = new List<string>();
        using (var d = new Disposable(() => lst.Add("Foo")))
        {
            d.Add(() => lst.Add("Bar"));
            d.Add(() => lst.Add("Baz"));
        }

        Assert.Equal(3, lst.Count);
        Assert.Equal("Baz", lst[0]);
        Assert.Equal("Bar", lst[1]);
        Assert.Equal("Foo", lst[2]);
    }

    [Fact]
    public void DisposingADisposable()
    {
        var lst = new List<string>();
        var d = new Disposable(() => lst.Add("Foo"));
        using (new Disposable(d))
        {
            Assert.Empty(lst);
        }

        Assert.Single(lst);
        Assert.Equal("Foo", lst[0]);
    }

    [Fact]
    public void DisposingContinuesPastExceptions()
    {
        var lst = new List<string>();
        var aggregateException = Assert.Throws<AggregateException>(() =>
        {
            using var d = new Disposable(() => lst.Add("Foo"));
            d.Add(() => throw new Exception("Bar"));
        });
        Assert.Single(aggregateException.InnerExceptions);
        Assert.Equal("Bar", aggregateException.InnerException?.Message);
        Assert.Single(lst);
        Assert.Equal("Foo", lst[0]);
    }

    [Fact]
    public void DisposeOnlyOnce()
    {
        var lst = new List<string>();
        var d = new Disposable(() => lst.Add("Foo")) as IDisposable;
        d.Dispose();
        Assert.Single(lst);
        Assert.Equal("Foo", lst[0]);
        d.Dispose();
        Assert.Single(lst);
    }

    [Fact]
    public void InvalidOperationToAddWhenAlreadyDisposed()
    {
        var d = new Disposable();
        ((IDisposable) d).Dispose();
        Assert.Throws<ObjectDisposedException>(() => d.Add(Functions.NoOp));
    }
}