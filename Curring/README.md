# Currying

Function [currying](https://en.wikipedia.org/wiki/Currying) is a specific *kind* of function transformation where we translate a single function that accepts multiple arguments into *multiple* functions that each accept a *single* argument.

This is a "normal" 3-argument function call, using a tuple:

```fsharp
boxVolume (3, 4, 5)
```

This is a "curried" *series of functions* that does the same thing:

```fsharp
boxVolume 3 4 5
```

Here's another example that includes the implementations:

```fsharp
let sum (a, b) = a + b

printfn "%d" (sum (1, 2))
// prints 3
```

And the same thing curried, with an explicit lambda:

```fsharp
let sum a =
    fun b -> a + b

printfn "%d" (sum 1 2)
// prints 3
```

The `sum` function only takes a *single* input, `a`. It returns a *new* function that takes a single input, `b`. This new function when called with a value for `b` will return the sum of `a` and `b`. *We'll talk later about why this is useful.*

In F#, `let sum a b = a + b` means exactly the same thing: [every function is curried by default](https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/#curried-functions).

## Assignment

In Doc2Doc, for some types of text files, we need to transform the font size of the text when rendering it onscreen.

Fix the `convertedFontSize` function. We are using a 3rd party code library that expects our function to be a curried series of functions that each take a single argument.

- `convertedFontSize` should take a single argument, `fontSize`, and return a new function.
- The returned function should take a single argument, `docType`, and return `fontSize` multiplied by the appropriate value for the given `docType`:
  - `"txt"`: `1`
  - `"md"`: `2`
  - `"docx"`: `3`
  - anything else: `failwith "invalid doc type"`

## Tip

Use [`match`](https://learn.microsoft.com/dotnet/fsharp/language-reference/match-expressions) on `docType`.
