# Decorators Practice

You can stack decorators, and you can use currying with decorators. In F#, stacking is just piping a function through several wrappers with `|>`.

```fsharp
type TextFunc = string -> unit

let toUppercase (func: TextFunc) : TextFunc =
    fun document -> func (document.ToUpper())

let getTruncate (length: int) (func: TextFunc) : TextFunc =
    fun document -> func (document[.. length - 1])

let printInput: TextFunc =
    (fun input -> printfn "%s" input)
    |> getTruncate 9 // currying
    |> toUppercase

printInput "Keep Calm and Carry On"
// prints: "KEEP CALM"
```

Notice that `getTruncate 9` first returns a decorator, which wraps the printing function. Then `toUppercase` wraps the result. When `printInput` is called, the text is converted to uppercase, then truncated to 9 characters before printing.

The **last** wrapper in the pipeline runs **first**, just like the top decorator in a Python stack.

## Assignment

Doc2Doc needs a feature that can take care of encoding characters as escape sequences in HTML documents.

> You might not know anything about HTML. That's fine. This assignment isn't about HTML directly.
> Just understand that it's a markup language like Markdown. Certain characters are interpreted as part of HTML syntax. In order to show those characters without interpreting them, they must be escaped. For exampe, `<` is replaced with `&lt;`

**Complete the replacer function**

1. [x] It takes as input two strings, `oldValue` and `newValue`, and a function, `decoratedFunc`.
2. [ ] It returns a wrapper that takes as input a string `text`. It uses the `.Replace()` string method to replace instances of `oldValue` with `newValue` in the `text`. Then it returns the result of passing the modified `text` to `decoratedFunc`.
3. [ ] Use a pipeline of `replacer` calls to decorate `tagPre`. The replacements must run in this order, so `&` must be the last one in the pipeline:
    1. [ ] Replace `"&"` with `"&amp;"`.
    2. [ ] Replace `"<"` with `"&lt;"`.
    3. [ ] Replace `">"` with `"&gt;"`.
    4. [ ] Replace `"\""` with `"&quot;"`.
    5. [ ] Replace `"'"` with `"&#x27;"`.
