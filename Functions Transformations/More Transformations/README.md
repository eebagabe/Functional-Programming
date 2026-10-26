# More Transformations

Here's some example code for you to reference as you work through the assignment:

```fsharp
let multiply x y = x * y

let add x y = x + y

let selfMath mathFunc =
    fun x -> mathFunc x x

let squareFunc = selfMath multiply
let doubleFunc = selfMath add

printfn "%d" (squareFunc 5)
// prints 25

printfn "%d" (doubleFunc 5)
// prints 10
```

## Assignment

Complete the `docFormatCheckerAndConverter` function.

It takes a `conversionFunction` and a list of `validFormats` as parameters. It should return a _new_ function that takes two parameters of its own:

- `filename`: The name of the file to be converted
- `content`: The content (body text) of the file to be converted

1. [ ] If the file extension of the `filename` is in the `validFormats` list, then it should return the result of calling the `conversionFunction` on the `content`.
2. [ ] Otherwise, it should fail with [`failwith`](https://learn.microsoft.com/dotnet/fsharp/language-reference/exception-handling/the-failwith-function) and the message `invalid file format`.

## Tip

You can use the [`.Split()`](https://learn.microsoft.com/dotnet/api/system.string.split) method on the `filename` to get the file extension. Then use [`List.contains`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#contains) to check if a value is in a list.

The `capitalizeContent` and `reverseContent` are "conversion functions" that will be passed into our `docFormatCheckerAndConverter` function by the tests.
