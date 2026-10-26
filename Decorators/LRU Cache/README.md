# LRU Cache

Python's `functools.lru_cache` is both a decorator and an example of memoization. F# has no built-in equivalent, but a higher-order `memoize` function does the same job in a few lines.

LRU stands for "least recently used". It's a type of cache that stores items up to a certain size limit. When it gets full, it makes space for new items by discarding the least recently used items first. The cache can be effective because items that are used a lot - like frequently repeated calls to the same function - are less likely to be discarded. They stay in-cache.

A memoizing wrapper stores the inputs and outputs of the decorated function. It speeds up repeated calls to a slow function with the same inputs. A function that reads from disk, makes network requests, or requires a lot of computation could be a good candidate for caching if it also sees many identical calls.

```fsharp
open System.Collections.Generic

let memoize (func: 'a -> 'b) =
    let cache = Dictionary<'a, 'b>()

    fun input ->
        match cache.TryGetValue input with
        | true, value -> value
        | _ ->
            let value = func input
            cache[input] <- value
            value

let rec factorial: int -> bigint =
    memoize (fun x -> if x = 0 then 1I else bigint x * factorial (x - 1))

factorial 10 // no cached results; makes 11 recursive calls
// 3628800
factorial 5 // just looks up cached result value
// 120
factorial 12 // makes 2 new recursive calls; the other 11 are cached
// 479001600
```

The recursive call goes through `factorial`, the memoized *value*, so every step is cached. Because `factorial` is a value and not a plain function, F# shows warning `FS0040`; it is safe here and can be silenced with `#nowarn "40"`.

Because `factorial` is recursive and the inputs are sequential numbers, it does get called repeatedly with the same inputs. Without caching, the function would be called 30 times in the code above. With `memoize`, the function is only called 13 times. You don't often need to compute factorials, but this example ties together how to use a decorator and memoization and recursion.

> This `memoize` has no size limit, so it never evicts anything. A real LRU cache would also drop the least recently used entries when full.

## Assignment

The creator of Doc2Doc is a huge fan of palindromes for some nerdy reason. Add a feature to check if a word is a palindrome.

1. [ ] Write a `memoize` function and use it to wrap the `isPalindrome` function.
2. [ ] Complete the `isPalindrome` function. It takes as input a `word` string and returns `true` if the word is a palindrome (such as "racecar"), or `false` otherwise.

Try to use recursion. Check the outer characters first, then move inwards until you reach the base case or find that the word is not a palindrome.
