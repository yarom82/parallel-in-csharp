using System;
using System.Diagnostics;

namespace parallel_in_csharp.src
{
    static class Logger
    {
        public static void LogStats(Stopwatch stopwatch, int counter, string methodName)
        {
            var separator = new String('*', 10);
            Console.WriteLine($"{separator} {methodName} method {separator}");
            Console.WriteLine($"Number of primes: {counter}");
            Console.WriteLine($"Time elapsed {stopwatch.Elapsed.TotalSeconds}");
        }
    }
}
