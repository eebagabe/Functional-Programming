# Match

Let's take another look at a sum type like the ones from the previous lessons:

```fsharp
type Color =
    | Red
    | Green
    | Blue
```

## Working With Unions

F# has a [`match` expression](https://learn.microsoft.com/dotnet/fsharp/language-reference/match-expressions) that tends to be a lot cleaner than a series of `if`/`elif`/`else` expressions when we're working with a fixed set of possible values (like a sum type):

```fsharp
let getHex color =
    match color with
    | Red -> "#FF0000"
    | Green -> "#00FF00"
    | Blue -> "#0000FF"
```

There is no default case: the compiler knows every possible `Color` and warns you if one is missing.

If you have two values to match, you can use a tuple:

```fsharp
type Shade =
    | Light
    | Dark

let getHex color shade =
    match color, shade with
    | Red, Light -> "#FFAAAA"
    | Red, Dark -> "#AA0000"
    | Green, Light -> "#AAFFAA"
    | Green, Dark -> "#00AA00"
    | Blue, Light -> "#AAAAFF"
    | Blue, Dark -> "#0000AA"
```

The values after `match` (`color` and `shade`) are compared against the patterns in each case (`Red, Light`). The first pattern that matches wins and its expression is the result. When you only handle some combinations, finish with the wildcard `_`, which matches anything.

## Assignment

Complete the `convertFormat` function. Using the union `DocFormat`, it should support 3 types of conversions. The target format is a `DocFormat option`, because it may be missing:

1. [ ] From `MD` to `Some HTML`:
   - Assume the content is a single `h1` tag in Markdown syntax - one string representing one line. Replace the leading `# ` with an `<h1>` and add a `</h1>` to the end.
   - Example: `# This is a heading` -> `<h1>This is a heading</h1>`
2. [ ] From `TXT` to `Some PDF`:
   - Simply add a `[PDF]` tag to the beginning and end of the content;
   - Notice the spaces between `[PDF]` tags and the content: `This is some text` -> `[PDF] This is some text [PDF]`
3. [ ] From `HTML` to `Some MD`:
   - Replace any `<h1>` tags with `# ` and remove any `</h1>` tags.
   - Example `<h1>This is a heading</h1>` -> `# This is a heading`
4. [ ] Any other conversion (including `None`):
   - Fail with `failwith`:
   ```cmd
   invalid type
   ```
