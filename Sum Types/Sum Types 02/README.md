# Sum Types

Python does not support sum types as well as statically typed languages. Python doesn't enforce your types before your code runs, so a function like this needs a final line to `raise` an `Exception` if a color is invalid:

```py
def color_to_hex(color: Color) -> str:
    if color == Color.GREEN:
        return "#00FF00"
    elif color == Color.BLUE:
        return "#0000FF"
    elif color == Color.RED:
        return "#FF0000"

    # handle the case where the color is invalid
    raise Exception("unknown color")
```

F# has a rich type system, so we can write the same thing like this:

```fsharp
type Color =
    | Red
    | Green
    | Blue

let colorToHex color =
    match color with
    | Green -> "#00FF00"
    | Blue -> "#0000FF"
    | Red -> "#FF0000"
```

Notice how there isn't any case for an unknown color? A `Color` value can only be one of the defined cases, and the compiler checks that the `match color` handles every case. If you remove the `Red` line, you get a warning before the code ever runs:

```
warning FS0025: Incomplete pattern matches on this expression. For example, the value 'Red' may indicate a case not covered by the pattern(s).
```

You can make it a hard error with `<TreatWarningsAsErrors>` or `--warnaserror:25`.

This static enforcement is a huge benefit of sum types, and F# gives it to us for free.
