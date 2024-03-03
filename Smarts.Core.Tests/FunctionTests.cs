using System.Linq;

namespace Smarts.Core.Tests;

public class FunctionTests
{
    [Fact]
    public void CallNoOp()
    {
        Functions.NoOp();
    }

    [Fact]
    public void IdentityOfAStruct()
    {
        const int num = 42;
        var identity = Functions.Identity(num);
        Assert.Equal(num, identity);
    }

    [Fact]
    public void IdentityOfAClass()
    {
        var obj = new object();
        var identity = Functions.Identity(obj);
        Assert.Same(obj, identity);
    }

    [Fact]
    public void IdentityUsageExample()
    {
        var fifteen = Enumerable.Range(1, 5).Select(Functions.Identity).Sum();
        Assert.Equal(15, fifteen);
    }
}