# Closures

A [closure](https://en.wikipedia.org/wiki/Closure_\(computer_programming\)) is a function that references variables from outside its own function body. The function definition _and its environment_ are bundled together into a single entity.

Put simply, a closure is just a function that **keeps track of some values** from the place where it was _defined_, no matter where it is executed later on.

## Example

The `concatter` function returns a lambda (yay higher-order functions!) that has a reference to an _enclosed_ `doc` value.

```fsharp
let concatter () =
    let doc = ref ""

    fun (word: string) ->
        doc.Value <- doc.Value + word + " "
        doc.Value

// save the returned function to 'harryPotterAggregator'
let harryPotterAggregator = concatter ()
harryPotterAggregator "Mr." |> ignore
harryPotterAggregator "and" |> ignore
harryPotterAggregator "Mrs." |> ignore
harryPotterAggregator "Dursley" |> ignore
harryPotterAggregator "of" |> ignore
harryPotterAggregator "number" |> ignore
harryPotterAggregator "four," |> ignore
harryPotterAggregator "Privet" |> ignore

printfn "%s" (harryPotterAggregator "Drive")
// Mr. and Mrs. Dursley of number four, Privet Drive
```

When `concatter ()` is called, it creates a new "stateful" function that _remembers_ the value of its internal `doc` cell. Each successive call to `harryPotterAggregator` appends to that same `doc`.

## Mutable state in closures

F# values are immutable by default. A `let mutable` local **cannot** be captured by a closure; the compiler stops you with:

```
The mutable variable 'doc' is used in an invalid way. Mutable variables cannot be captured by closures.
```

To keep changing state inside a closure, use a [reference cell](https://learn.microsoft.com/dotnet/fsharp/language-reference/reference-cells) (`ref`). Read it with `.Value` and update it with `.Value <- newValue`.

## Assignment

Doc2Doc keeps track of how many words are in a collection of documents.

1. [ ] Complete the `wordCountAggregator` function.
    1. [ ] It should return a function that calculates the number of words in its input (`doc`, a string).
    2. [ ] It should then add that number to an _enclosed_ `count` value and return the new `count`.

In other words, it keeps a running total of the `count` cell within a closure.

## Tip

I used [`String.Split`](https://learn.microsoft.com/dotnet/api/system.string.split) with `StringSplitOptions.RemoveEmptyEntries` to count the number of words in the `doc` string.

Run the tests with `dotnet fsi main_test.fsx`.
