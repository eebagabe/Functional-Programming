type TextFunc = string -> string

let replacer (oldValue: string) (newValue: string) (decoratedFunc: TextFunc) : TextFunc =
    fun text -> decoratedFunc (text.Replace(oldValue, newValue))


// the last replacer runs first, like the outermost Python decorator
let tagPre: TextFunc =
    (fun text -> $"<pre>{text}</pre>")
    |> replacer "'" "&#x27;"
    |> replacer "\"" "&quot;"
    |> replacer ">" "&gt;"
    |> replacer "<" "&lt;"
    |> replacer "&" "&amp;"
