using System;
using System.Collections.Generic;

namespace Smarts.Core
{
    public sealed class Disposable : IDisposable
    {
        private readonly Stack<IDisposable> _toDispose;
        private bool _disposed;

        public Disposable()
        {
            _toDispose = new Stack<IDisposable>();
        }

        public Disposable(IDisposable disposable) : this()
        {
            Add(disposable);
        }

        public Disposable(Action onDispose) : this()
        {
            Add(onDispose);
        }

        public void Add(Action onDispose)
        {
            Add(new DisposeAction(onDispose));
        }

        public T Add<T>(T disposable) where T : IDisposable
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Cannot add to an already disposed instance");
            }
            _toDispose.Push(disposable);
            return disposable;
        }

        void IDisposable.Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            var exceptions = new List<Exception>();
            while (_toDispose.Count > 0)
            {
                try
                {
                    _toDispose.Pop().Dispose();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        private class DisposeAction : IDisposable
        {
            private readonly Action _onDispose;

            public DisposeAction(Action onDispose)
            {
                _onDispose = onDispose;
            }

            void IDisposable.Dispose()
            {
                _onDispose();
            }
        }
    }
}
