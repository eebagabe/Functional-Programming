# Decorators

Remember function transformations where a (higher-order) function takes a function and returns a function with new behavior? Python has [decorators](https://docs.python.org/3/glossary.html#term-decorator), a special `@` syntax for that. F# has no special syntax: a decorator is just a higher-order function that you apply yourself.

**Example:**

```fsharp
let vowelCounter (funcToDecorate: string -> unit) =
    let vowelCount = ref 0

    fun (doc: string) ->
        let vowels = doc.ToLower() |> Seq.filter (fun c -> "aeiou".Contains c) |> Seq.length
        vowelCount.Value <- vowelCount.Value + vowels
        printfn "Vowel count: %d" vowelCount.Value
        funcToDecorate doc

let processDoc = vowelCounter (fun doc -> printfn "Document: %s" doc)

processDoc "What"
// Vowel count: 1
// Document: What

processDoc "A wonderful"
// Vowel count: 5
// Document: A wonderful

processDoc "world"
// Vowel count: 6
// Document: world
```

`processDoc` is "decorated" with the `vowelCounter` function. `vowelCounter` is called once, when `processDoc` is defined, but the function that it returns is called every time `processDoc` is called. That's why `vowelCount` is preserved and printed after each time.

## It's Just a Function Call

In Python, these two pieces of code are *identical*:

### With Decorator (Python)

```py
@vowel_counter
def process_doc(doc):
    print(f"Document: {doc}")
```

### Without Decorator (Python)

```py
def process_doc(doc):
    print(f"Document: {doc}")

process_doc = vowel_counter(process_doc)
```

F# only has the second form. You can write it with a pipe too:

```fsharp
let processDoc = (fun doc -> printfn "Document: %s" doc) |> vowelCounter
```

## Assignment

The provided `fileTypeAggregator` function is intended to decorate other functions. It assumes that the function it decorates takes exactly 2 curried string arguments.

**Create a `processDoc` function** that's decorated by `fileTypeAggregator`. It should return the following string:

```fsharp
$"Processing doc: '{doc}'. File Type: {fileType}"
```

Where `doc` and `fileType` are its arguments.
