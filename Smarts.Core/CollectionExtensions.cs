using System;
using System.Collections.Generic;
using System.Linq;

namespace Smarts.Core
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                collection.Add(value);
            }
        }

        public static void PadRight<T>(this IList<T> list, int paddedLength, T paddingValue)
        {
            if (paddedLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(paddedLength), "The padded length must be positive.");
            }

            var padAmount = paddedLength - list.Count;
            if (padAmount < 1)
            {
                return;
            }

            list.AddRange(Enumerable.Repeat(paddingValue, padAmount));
        }

        public static void PadRight<T>(this IList<T> list, int paddedLength, Func<T> paddingFactory)
        {
            list.PadRight(paddedLength, _ => paddingFactory());
        }

        public static void PadRight<T>(this IList<T> list, int paddedLength, Func<int, T> paddingFactory, int offset = 0)
        {
            if (paddedLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(paddedLength), "The padded length must be positive.");
            }

            var padAmount = paddedLength - list.Count;
            if (padAmount < 1)
            {
                return;
            }

            list.AddRange(Enumerable.Range(offset, padAmount).Select(paddingFactory));
        }
    }
}