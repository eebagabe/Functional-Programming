# Args and Kwargs

Python has `*args` and `**kwargs` to accept a *variable* number of positional and keyword arguments. F# has no direct equivalent for functions: every `let` function has a fixed number of curried parameters. When we need a variable number of values, we pass them as data:

- a variable number of positional arguments becomes a *list*
- a variable number of named arguments becomes a *map* (or a list of `(key, value)` tuples)

```fsharp
let printArguments (args: obj list) (kwargs: Map<string, obj>) =
    printfn "Positional arguments: %A" args
    printfn "Keyword arguments: %A" kwargs

printArguments [ "hello"; "world" ] (Map [ "a", 1; "b", 2 ])
// Positional arguments: ["hello"; "world"]
// Keyword arguments: map [("a", 1); ("b", 2)]
```

## Positional Arguments

Positional arguments are the ones you're already familiar with, where the order of the arguments matters. Like this:

```fsharp
let sub a b = a - b

// a=3, b=2
let res = sub 3 2
// res = 1
```

## Named Arguments

F# supports [named arguments](https://learn.microsoft.com/dotnet/fsharp/language-reference/parameters-and-arguments#named-arguments) only on *methods* (members of a type), not on `let` functions. With named arguments, *order does not matter*:

```fsharp
type Calc =
    static member Sub(a: int, b: int) = a - b

Calc.Sub(b = 3, a = 2) // -1
Calc.Sub(a = 3, b = 2) // 1
```

Methods can also take a variable number of arguments with [`[<ParamArray>]`](https://learn.microsoft.com/dotnet/fsharp/language-reference/parameters-and-arguments#parameter-arrays). For plain functions, a list or a map is simpler.

## Assignment

At Doc2Doc, we need better internal debugging tools. **Complete the `argsLogger` function.** It takes a list of positional values and a map of named values and prints them to the console.

1. [ ] Print each positional argument *sequentially* using numbers and periods as list markers, starting with `1.` . For example:

```fsharp
argsLogger [ "what's"; "up"; "doc" ] Map.empty
```

prints to the console:

```
1. what's
2. up
3. doc
```

2. [ ] Print the named arguments *alphabetically by key*, using asterisks (`*`) as list markers, and with a colon (`:`) between the key and value. For example:

```fsharp
argsLogger [ "hi"; "there" ] (Map [ "age", box 17; "date", box "July 4 1776" ])
```

prints to the console:

```
1. hi
2. there
* age: 17
* date: July 4 1776
```

## Tips

- [`List.iteri`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#iteri) gives you the index of each item.
- An F# `Map` is always sorted by key, so [`Map.iter`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#iter) already visits the keys alphabetically.
- Use the `%O` format to print an `obj` value.

Run the examples with `dotnet fsi main.fsx`.
