# Currying Practice

Remember, [currying](https://en.wikipedia.org/wiki/Currying) is when we take a function that accepts multiple arguments and convert it into a series of functions that each accept a single argument.

In F#, functions are curried by default. This definition:

```fsharp
let boxVolume length width height = length * width * height
```

can be called with all its arguments:

```fsharp
let finalVolume = boxVolume 3 4 5
printfn "%d" finalVolume
// 60
```

- `boxVolume 3` returns a new function that accepts a single integer and returns a new function
- `boxVolume 3 4` returns another new function that accepts a single integer and returns the result
- `boxVolume 3 4 5` returns the final result

Here's another way of calling it, where each function is stored in a value before being called ([partial application](https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/#partial-application-of-arguments)):

```fsharp
let withLength3 = boxVolume 3
let withLen3Width4 = withLength3 4
let finalVolume = withLen3Width4 5
printfn "%d" finalVolume
// 60
```

The same function written with explicit lambdas, the way you'd write it in a language without automatic currying:

```fsharp
let boxVolume length =
    fun width ->
        fun height -> length * width * height
```

## Assignment

Doc2Doc needs to be able to find the number of lines in a document that contain a specific sequence of characters. For example, given the following document:

```
aaaa
bbbb
ccdd
aabb
```

How many lines contain the sequence "aa"? The answer is 2: "aaaa" and "aabb".

**Complete the `linesWithSequence` function.** It should be curried so it can be called like this:

```fsharp
let numLines = linesWithSequence char length doc
```

The "sequence" is built from the first two arguments with `String(char, length)`. It works like this:

| Character | Length | Sequence   |
| --------- | ------ | ---------- |
| 'a'       | 3      | "aaa"      |
| 'b'       | 2      | "bb"       |
| '\*'      | 4      | "\*\*\*\*" |

Build the sequence once, then return a function that accepts the final parameter, a `doc` string, and returns the number of lines that contain the sequence.

1. [ ] Build the sequence from `char` and `length`.
2. [ ] Return a function that accepts a `doc`.
3. [ ] [Split](https://learn.microsoft.com/dotnet/api/system.string.split) the `doc` into lines.
4. [ ] Use [`Array.fold`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#fold) to count the number of lines that [contain](https://learn.microsoft.com/dotnet/api/system.string.contains) the sequence.
5. [ ] Return the count.
