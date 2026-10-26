// memoized recursion goes through a value, not a function
#nowarn "40"

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


let rec isPalindrome: string -> bool =
    memoize (fun word ->
        word.Length <= 1
        || word[0] = word[word.Length - 1] && isPalindrome word[1 .. word.Length - 2])
