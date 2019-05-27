# 1.1.0 (Proposed)
- 🆕 `PadLeft` extension method on `IList<T>` to provide the left-hand
  variation of the existing `PadRight` extension.
- 🆕 `Functions.Identity` function passing through a value unchanged.

# 1.0.0 (2019-05-26)
- 🆕 `AsForeground` and `AsBackground` extension methods to change console
  colours with the `IDisposable` pattern resetting the previous colour.
- 🆕 `AddRange` extension method bringing the functionality of `List<T>`'s
  method to all `ICollection<T>`.
- 🆕 `PadRight` extension method on `IList<T>` to pad a list using either a
  fixed value or a factory function.
- 💔 `Disposable` is now `sealed` preventing subclassing.

# 0.1.0 (2019-05-25)
- 🆕 `Disposable` class for managing `IDisposable` instances.
- 🆕 `AcquireAsync` extension method for `SemaphoreSlim` to release semaphore
  with the `IDisposable` pattern.
