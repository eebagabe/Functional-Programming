# Union Types

Python simulates the shape of sum types with classes and union type hints like `Parsed | ParseError`, but the hints are not enforced at runtime.

In F#, a [discriminated union](https://learn.microsoft.com/dotnet/fsharp/language-reference/discriminated-unions) *is* the union type, and the compiler enforces it:

```fsharp
type ParseResult =
    | Parsed of docName: string * text: string
    | ParseError of docName: string * err: string

let parseDocument (docName: string) (content: string) : ParseResult = ...
```

The `ParseResult` type means, "This function returns either a `Parsed` value or a `ParseError` value." Each case carries its own data, and there's no class hierarchy to maintain.

One of the most common union types in F# is the built-in [`Option`](https://learn.microsoft.com/dotnet/fsharp/language-reference/options): `string option` is either `Some "text"` or `None`, a value that may be a string, or may be missing if the string isn't available yet or couldn't be retrieved. F# also has [`Result<'T, 'Error>`](https://learn.microsoft.com/dotnet/fsharp/language-reference/results) for "a value or an error".

In functional programming, union types are used constantly to make "this or that" situations explicit: some value or none; a result from a function or an error.

## Assignment

Doc2Doc needs to parse documents without throwing exceptions for ordinary failures. Complete the `parseDocument` and `displayParseResult` functions.

1. [ ] `parseDocument` accepts 2 string arguments, `docName` and `content`. It should return a `Parsed` value if `content` is not empty:
   - `docName` the provided document name
   - `text`: the provided content
2. [ ] `parseDocument` should return a `ParseError` if `content` is empty:
   - `docName`: the provided document name
   - `err`: `"no content"`
3. [ ] `displayParseResult` accepts a `ParseResult` value and returns a string:
   - If the provided value is `Parsed`, return `Parsed <docName>: <N> characters`, where `<N>` is the length of the parsed text.
   - If the provided value is `ParseError`, return `Failed <docName>: <err>`.

   > Tip: Use `match` to check which case of the union you're working with.
