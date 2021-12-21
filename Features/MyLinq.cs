using System.Collections.Generic;

namespace Features.Linq
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            var count = 0;
            foreach(var s in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
