# Closure Practice

Doc2Doc should be able to add [CSS](https://en.wikipedia.org/wiki/CSS) styling to an HTML file. CSS uses selectors to identify the HTML element to add the style property. Essentially, styles are a chain of keys and values.

```css
p {
  color: red;
}
```

- **Selector:** `p` (targets all `<p>` elements)
- **Property:** `color`
- **Value:** `red`

Complete the `cssStyles` function. It accepts a nested map as input, `initialStyles: Map<string, Map<string, string>>`, and returns a function, `addStyle`.

1. [ ] Keeps the current styles in a closure, starting from `initialStyles`.

F# maps are immutable, so `Map.add` returns a _new_ map and never changes the original. There is no need for a deep copy: `initialStyles` can't be modified.

2. [ ] Returns an `addStyle` function that:
    1. [ ] Takes three string arguments: `selector`, `property`, and `value`. `selector` is a key in the styles map and its value should be a map.
    2. [ ] Checks if the `selector` exists in the map. If not, starts from an empty map for the `selector` value.
    3. [ ] Then adds or updates the `property` with the given `value` for the selector map.
    4. [ ] Returns the updated styles.

For example:

```fsharp
let initialStyles =
    Map [ "body", Map [ "background-color", "white"; "color", "black" ]
          "h1", Map [ "font-size", "16px"; "padding", "10px" ] ]

let addStyle = cssStyles initialStyles

let newStyles = addStyle "p" "color" "grey"
// map [ ("body", map [ ("background-color", "white"); ("color", "black") ])
//       ("h1", map [ ("font-size", "16px"); ("padding", "10px") ])
//       ("p", map [ ("color", "grey") ]) ]
```

## Tip

Reminder, you can read an optional key and replace a nested map like so:

```fsharp
let current = styles |> Map.tryFind selector |> Option.defaultValue Map.empty
styles |> Map.add selector (current |> Map.add property value)
```
