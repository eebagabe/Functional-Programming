# Referential Transparency

Pure functions are always [referentially transparent](https://www.baeldung.com/cs/referential-transparency#referential-transparency).

"Referential transparency" is a fancy way of saying that a function call can be replaced by its would-be return value because it's the same every time. **Referentially transparent functions can be safely memoized.** For example `add 2 3` can be smartly replaced by the value `5`.

The great thing about pure functions is that they can always be *safely* memoized. Impure functions can't be because they might do something in addition to returning a static value, or they might return different values given the same arguments.

## Should I Always Memoize?

No! Memoization is a *tradeoff* between memory and speed. If your function is fast to execute, it's probably not worth memoizing, because the amount of RAM (memory) your program will need to store the results will go way up.

It's also a bunch of extra code to write, so you should only do it if you have a good reason to.
