# parallel-in-charp

## `static void SynchronousMethod(int n)`
## `static void ParallelMethod(int n)`
## `static void ParallelMethodWithNoLock(int n)`

This application checks the number of prime numbers from 0 to 10M.
It does it in variuos ways.
Synchronously.
Parallel (using TPL) with lock object.
Parallel without locking.

The results are:

- *** SynchronousMethod method ***<br>
Number of primes: 664579<br>
Time elapsed 3.4014699

- *** ParallelMethod method *** <br>
Number of primes: 664579<br>
Time elapsed 5.1402326

- *** ParallelMethodWithNoLock method ***<br>
Number of primes: 648987<br>
Time elapsed 0.7901389

Using Parllel has shorten the time but we had problem with shared data. Hence, the result was incorrect.
When locking the shared data we'd increase the duration time.
