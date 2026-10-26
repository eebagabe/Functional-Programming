# Decorators

- Dificulty: 8

In Python, `*args` and `**kwargs` let one decorator work on functions with different signatures. In F#, a function's type includes its parameters, so a wrapper must know the shape of the function it wraps. A common trick is to give every decorated function the same shape, for example a single list of arguments.

## Example

The `logCallCount` function below doesn't care about what the decorated function does. It just wants to count how many times the function is called. However, it still needs to pass the argument through to the wrapped function.

```fsharp
let logCallCount (funcToDecorate: 'a -> 'b) =
    let count = ref 0

    fun (arg: 'a) ->
        count.Value <- count.Value + 1
        printfn "Called %d times" count.Value

        // Pass the argument to the decorated function
        funcToDecorate arg
```

- `'a -> 'b` is a [generic](https://learn.microsoft.com/dotnet/fsharp/language-reference/generics/) function type. It means "any function that takes one value and returns anything." A tuple or a list counts as one value.

### Assignment

Complete the `markdownToTextDecorator` function. It decorates a function that takes a `string list`. It will run the decorated function, but first strip out any Markdown heading symbols (see below for an explanation of Markdown headings).

For example, if the decorated function is called like this:

```fsharp
formatAsEssay [ "# My Title"; "Hello"; "## Done" ]
```

The wrapper should convert every value, then call the original function like this:

```fsharp
formatAsEssay [ "My Title"; "Hello"; "Done" ]
```

The same idea applies to any number of arguments:

```fsharp
concat [ "# First"; "## Second" ]
```

should become:

```fsharp
concat [ "First"; "Second" ]
```

`markdownToTextDecorator` should return a wrapper function that takes a `string list`. The wrapper should:

1. [ ] Convert every argument with `convertMdToTxt`.
2. [ ] Call the decorated function with the converted arguments.
3. [ ] Return the decorated function's result.

### Tips

- Take a look at `formatters.fsx` to see what the formatter functions do. They pattern match on the list to get each argument by position.
- One way to convert each Markdown string to plain text is with [`List.map`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#map).
- The provided `convertMdToTxt` function takes a string of Markdown text and returns the text with any "heading" symbols removed. For example:

- Input: # This is a heading | Output: This is a heading
