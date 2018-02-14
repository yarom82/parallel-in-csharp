using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace parallel_in_csharp.src
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10000000;
            SynchronousMethod(n);
            ParallelMethodWithBadLock(n);
            ParallelMethodWithLock(n);
            ParallelMethodWithNoLock(n);
        }

        static void SynchronousMethod(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var counter = 0;

            for (var i = 0; i <= n; i++)
            {
                if (Prime.IsPrime(i))
                    counter++;
            }

            stopwatch.Stop();
            Logger.LogStats(stopwatch, counter, "SynchronousMethod");
        }

        private static Object thisLock = new Object();  

        static void ParallelMethodWithBadLock(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var counter = 0;

            Parallel.For(0, n, i => {
                lock (thisLock)
                {
                    if (Prime.IsPrime(i))
                    {
                        counter++;
                    }
                }
            });

            stopwatch.Stop();
            Logger.LogStats(stopwatch, counter, "ParallelMethodWithBadLock");
        }

        static void ParallelMethodWithLock(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var counter = 0;

            Parallel.For(0, n, i => {
                if (Prime.IsPrime(i))
                {
                    lock (thisLock)
                    {
                        counter++;
                    }
                }
            });

            stopwatch.Stop();
            Logger.LogStats(stopwatch, counter, "ParallelMethodWithLock");
        }

        static void ParallelMethodWithNoLock(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var counter = 0;

            Parallel.For(0, n, i => {
                if (Prime.IsPrime(i))
                    counter++;
            });

            stopwatch.Stop();
            Logger.LogStats(stopwatch, counter, "ParallelMethodWithNoLock");
        }
    }
}
