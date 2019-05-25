# Smarts

## What is Smarts?

Smarts is a collection of classes to help perform everyday tasks in .NET code.

# Build Status
## master
[![Build Status](https://dev.azure.com/rhysparry/Smarts/_apis/build/status/rhysparry.Smarts?branchName=master)](https://dev.azure.com/rhysparry/Smarts/_build/latest?definitionId=1&branchName=master)
## develop
[![Build Status](https://dev.azure.com/rhysparry/Smarts/_apis/build/status/rhysparry.Smarts?branchName=develop)](https://dev.azure.com/rhysparry/Smarts/_build/latest?definitionId=1&branchName=develop)

## `Disposable`

You can use the `Smarts.Core.Disposable` class to help work with `IDisposable`
instances.

- Create an `IDisposable` that does nothing.
- Create an `IDisposable` that runs an `Action` on disposal.
- Stack multiple `IDisposable` instances (or actions)

Example:

```csharp
using (var disposer = new Disposable())
{
    var stream = disposer.Add(new Stream());
    var streamReader = disposer.Add(new StreamReader(stream))

    // Do something with the streamReader
}
```

In the above example the `StreamReader` will be disposed first as we dispose in
the reverse order from which the `IDisposable` instances are added.

We also return the `IDisposable` instance as it is currently typed so that the
call to the `Add` method can be made inline.

The most common usage will probably be to perform some action on disposal. This
could normally be done with a `try`/`finally` block, but nesting can get
cumbersome. It also makes it easier to return an `IDisposable` which will do
this cleanup.

```csharp
var currentFg = Console.ForegroundColor;
using (new Disposable(() => Console.ForegroundColor = currentFg))
{
    Console.ForegroundColor = ConsoleColor.Black;
}
```

## Semaphore Extensions

Easily manage acquiring and releasing a semaphore with the `AcquireAsync`
extension method on `SemaphoreSlim`.

Example:

```csharp
var semaphore = new SemaphoreSlim(1);

using (await semaphore.AcquireAsync())
{
    // Do things protected by the semaphore
}

// The semaphore will be automatically released.
```

## Console Extensions

Adjust colours on the console with automatic resetting to previous values with
the `IDisposable` pattern. `Console.ResetColor()` sets everything back to the
default values, making it great for the end of your application, but not ideal
for stacking possible changes. This helper makes it easy to keep track of the
previous value, even when it isn't the default.

Example:

```csharp
using (ConsoleColor.Red.AsForeground())
{
    Console.Write("Error ");
}
Console.Write("Something went wrong");
```

This allows nesting of colour changes, so you can keep things isolated to your
functions.

## Collection Extensions

### `AddRange()`

Adding multiple values to a collection is pretty common, but not all the
collection types have an `AddRange()` method like `List<T>`. This gap is filled
with an `AddRange()` extension method on `ICollection<T>`.

### `PadRight()`

An `IList<T>` can be padded with arbitrary values or values generated with a
factory function using the various `PadRight()` extension methods. This will
add as many elements as necessary to make the list the desired length.

If the list is already the required length (or longer) the function will not
alter the list.

If a negative number is specified as the desired length the function will throw
an `ArgumentOutOfRangeException`.

With a fixed value:

```csharp
var list = new List<int> {1, 2, 3};
list.PadRight(5, 0);

// list is now [1, 2, 3, 0, 0]
```

With a factory:

```csharp
var random = new Random(42);
var list = new List<int> {1, 2, 3};
list.PadRight(5, () => random.Next(7));

// list is now [1, 2, 3, 4, 0] (random seed was fixed)
```

With a factory receiving an integer offset:

```csharp
var list = new List<int> {1, 2, 3};
list.PadRight(5, i => i + 1);

// list is now [1, 2, 3, 1, 2] (by default the offset starts at zero)
```

With a factory receiving an integer offset adjusted by a fixed value:

```csharp
var list = new List<int> {1, 2, 3};
list.PadRight(5, i => i + 1, 3);

// list is not [1, 2, 3, 4, 5]
```
