using System;
using System.Collections.Generic;
using System.Linq;

namespace Smarts.Core.Tests;

public class CollectionExtensionTests
{
    [Fact]
    public void AddRangeAddsValuesToAHashSet()
    {
        var values = new HashSet<int> {10, 11, 12, 13};
        values.AddRange(Enumerable.Range(1, 10));
        Assert.Equal(13, values.Count);
        Assert.All(values, i => Assert.InRange(i, 1, 13));
    }

    [Fact]
    public void AddRangeStillWorksWithList()
    {
        var values = new List<int>();
        values.AddRange(Enumerable.Range(1, 10));
        Assert.Equal(10, values.Count);
        Assert.All(values, i => Assert.InRange(i, 1, 10));
    }

    [Fact]
    public void PadRightThrowsWhenNegativeLength()
    {
        var list = new List<int> {1, 2, 3};
        Assert.Throws<ArgumentOutOfRangeException>(() => list.PadRight(-1, 4));
    }

    [Fact]
    public void PadRightPadsProperly()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(10, 2);
        Assert.Equal(10, list.Count);
        Assert.Equal(20, list.Sum());
        Assert.Equal(14, list.Skip(3).Sum());
    }

    [Fact]
    public void PadRightLengthAlreadyPaddedLength()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(3, 9);
        Assert.Equal(3, list.Count);
        Assert.Equal(6, list.Sum());
    }

    [Fact]
    public void PadRightLengthGreaterThanPaddedLength()
    {
        var list = new List<int> {1, 2, 3, 4, 5};
        list.PadRight(3, 23);
        Assert.Equal(5, list.Count);
        Assert.Equal(15, list.Sum());
    }

    [Fact]
    public void PadRightFactoryFunctionThrowsWhenNegativeLength()
    {
        var list = new List<int> {1, 2, 3};
        Assert.Throws<ArgumentOutOfRangeException>(() => list.PadRight(-1, () => 4));
    }

    [Fact]
    public void PadRightFactoryFunctionPadsProperly()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(10, () => 2);
        Assert.Equal(10, list.Count);
        Assert.Equal(20, list.Sum());
        Assert.Equal(14, list.Skip(3).Sum());
    }

    [Fact]
    public void PadRightFactoryFunctionLengthAlreadyPaddedLength()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(3, () => 9);
        Assert.Equal(3, list.Count);
        Assert.Equal(6, list.Sum());
    }

    [Fact]
    public void PadRightFactoryFunctionLengthGreaterThanPaddedLength()
    {
        var list = new List<int> {1, 2, 3, 4, 5};
        list.PadRight(3, () => 23);
        Assert.Equal(5, list.Count);
        Assert.Equal(15, list.Sum());
    }

    [Fact]
    public void PadRightFactoryWithDefaultOffset()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(5, i => i + 1);
        Assert.Equal(5, list.Count);
        Assert.Equal(9, list.Sum());
        Assert.Equal(3, list.Skip(3).Sum());
    }

    [Fact]
    public void PadRightFactoryWithCustomOffset()
    {
        var list = new List<int> {1, 2, 3};
        list.PadRight(5, i => i + 1, 10);
        Assert.Equal(5, list.Count);
        Assert.Equal(29, list.Sum());
        Assert.Equal(23, list.Skip(3).Sum());
    }

    [Fact]
    public void PadLeftThrowsWhenNegativeLength()
    {
        var list = new List<int> {1, 2, 3};
        Assert.Throws<ArgumentOutOfRangeException>(() => list.PadLeft(-1, 4));
    }

    [Fact]
    public void PadLeftPadsProperly()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(10, 2);
        Assert.Equal(10, list.Count);
        Assert.Equal(20, list.Sum());
        Assert.Equal(14, list.Take(7).Sum());
    }

    [Fact]
    public void PadLeftLengthAlreadyPaddedLength()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(3, 9);
        Assert.Equal(3, list.Count);
        Assert.Equal(6, list.Sum());
    }

    [Fact]
    public void PadLeftLengthGreaterThanPaddedLength()
    {
        var list = new List<int> {1, 2, 3, 4, 5};
        list.PadLeft(3, 23);
        Assert.Equal(5, list.Count);
        Assert.Equal(15, list.Sum());
    }

    [Fact]
    public void PadLeftFactoryFunctionThrowsWhenNegativeLength()
    {
        var list = new List<int> {1, 2, 3};
        Assert.Throws<ArgumentOutOfRangeException>(() => list.PadLeft(-1, () => 4));
    }

    [Fact]
    public void PadLeftFactoryFunctionPadsProperly()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(10, () => 2);
        Assert.Equal(10, list.Count);
        Assert.Equal(20, list.Sum());
        Assert.Equal(14, list.Take(7).Sum());
    }

    [Fact]
    public void PadLeftFactoryFunctionLengthAlreadyPaddedLength()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(3, () => 9);
        Assert.Equal(3, list.Count);
        Assert.Equal(6, list.Sum());
    }

    [Fact]
    public void PadLeftFactoryFunctionLengthGreaterThanPaddedLength()
    {
        var list = new List<int> {1, 2, 3, 4, 5};
        list.PadLeft(3, () => 23);
        Assert.Equal(5, list.Count);
        Assert.Equal(15, list.Sum());
    }

    [Fact]
    public void PadLeftFactoryWithDefaultOffset()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(5, i => i + 1);
        Assert.Equal(5, list.Count);
        Assert.Equal(9, list.Sum());
        Assert.Equal(3, list.Take(2).Sum());
    }

    [Fact]
    public void PadLeftFactoryWithCustomOffset()
    {
        var list = new List<int> {1, 2, 3};
        list.PadLeft(5, i => i + 1, 10);
        Assert.Equal(5, list.Count);
        Assert.Equal(29, list.Sum());
        Assert.Equal(23, list.Take(2).Sum());
    }
}