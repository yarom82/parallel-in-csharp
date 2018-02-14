Parallel Programming in C#
==========================

## `static void SynchronousMethod(int n)`
## `static void ParallelMethodWithBadLock(int n)`
## `static void ParallelMethodWithLock(int n)`
## `static void ParallelMethodWithNoLock(int n)`

This application checks the number of prime numbers from 0 to 10M.<br>
It does it in variuos ways:
- Synchronously (~15 sec)
- Parallel (using TPL) with lock object at a bad location (~8 sec)
- Parallel (using TPL) with lock object (~3 sec)
- Parallel without locking (~2.5 sec)

The results are:

- *** SynchronousMethod method ***<br>
Number of primes: 664579<br>
Time elapsed 15.0955797

- *** ParallelMethodWithLock method *** <br>
Number of primes: 664579<br>
Time elapsed 3.1729963

- *** ParallelMethodWithBad method *** <br>
Number of primes: 664579<br>
Time elapsed 8.3274148

- *** ParallelMethodWithNoLock method ***<br>
Number of primes: 648987<br>
Time elapsed 2.5688005

## Conclusions:
Using Parllel has shorten the time but we had problem with shared data which returned incorrect result.<br>
When used locking, we'd increase the duration time, but setting the lock only at the shared data did the job.

## Build

Prerequisites:
- [.NET Core SDK](https://dot.net/core) (>2.1.4)

Run `dotnet build` from the solution directory.

## Developed

- [VS Code](https://code.visualstudio.com/) with [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
