# Smarts

## What is Smarts?

Smarts is a collection of classes to help perform common tasks in .NET code.

## `Disposable`

You can use the `Smarts.Core.Disposable` class to help work with `IDisposable`
instances.

- Create an `IDisposable` that does nothing.
- Create an `IDisposable` that runs an `Action` on disposal.
- Stack multiple `IDisposable` instances (or actions)

Example:

```
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

```
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

```
var semaphore = new SemaphoreSlim(1);

using (await semaphore.AcquireAsync())
{
    // Do things protected by the semaphore
}

// The semaphore will be automatically released.
```
