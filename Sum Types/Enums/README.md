# Enums

So far, we've used discriminated unions to model the different cases in a sum type, where each case can carry its own data.

If what you're trying to represent is a fixed set of values, F# has another option: [enums](https://learn.microsoft.com/dotnet/fsharp/language-reference/enumerations)

Let's say we have a `Color` that we want to restrict to only three possible values:

- `RED`
- `GREEN`
- `BLUE`

We could use a plain old `string` to represent these values, but that's annoying because we have to keep track of the "valid" values and defensively check for invalid ones all over our codebase. Instead we can use an enum:

```fsharp
type Color =
    | RED = 1
    | GREEN = 2
    | BLUE = 3

printfn "%A" Color.RED // This works, prints 'RED'
printfn "%A" Color.TEAL // This doesn't even compile
```

The syntax looks like a discriminated union, but every case has an integer value (`= 1`). That's what makes it an enum.

Now `Color` is a sum type! There are a few benefits:

1. A `Color` can only be `RED`, `GREEN`, or `BLUE`. If you try to use `Color.TEAL`, the compiler refuses to build the code.
2. There is a central place to see the "valid" values for a `Color`.
3. Each `Color` has a "name" (e.g. `RED`) and an integer value (e.g. `1`). The value can be useful if you need to store, compare, or serialize the enum in a specific way.

### Enums vs. discriminated unions

Enums are .NET integers underneath, so a value outside the list can still sneak in through a cast (`enum<Color> 42`). That's why a `match` on an enum still needs a `_` case. Discriminated unions don't have that hole, and their cases can carry data. Prefer unions in F# code; use enums when you need the integer values (interop, storage, flags).

## Assignment

Create an enum called `Doctype` with values:

- `PDF`
- `TXT`
- `DOCX`
- `MD`
- `HTML`

> Tip: Don't forget to give each case an integer value, or you'll get a union instead of an enum!
