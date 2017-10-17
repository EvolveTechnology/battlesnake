using System;
using System.Collections.Generic;

namespace NetSnake.Extensions
{
    public static class ForEachExtensions
    {
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (var t in list)
                action(t);
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var t in list)
                action(t);
        }
    }
}