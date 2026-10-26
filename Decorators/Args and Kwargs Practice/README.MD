# Args and Kwargs Practice

Doc2Doc should be extensible to allow for third-party plugins. These plugins will be configurable.

## Assignment

Complete the `configurePluginDecorator` function. It decorates a `func` that takes its named settings as a `Map<string, string>`, but the wrapper function it returns takes a list of key/value tuples, `(string * string) list`.

1. [ ] Return a wrapper function that takes `args: (string * string) list`:
   1. [ ] Within the wrapper function, convert the `args` into a map with [`Map`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html) (or `Map.ofList`).
   2. [ ] Return the result of passing this map into `func`.

Each plugin (see `plugins.fsx`) reads the keys it knows with `Map.tryFind` and falls back to its own defaults.

```fsharp
let pluginConfig =
    configureBackups [ "path", "~/duplicates"; "prefix", "duplicate_"; "extension", ".rtf" ]

// pluginConfig:
// map [ ("extension", ".rtf"); ("path", "~/duplicates"); ("prefix", "duplicate_") ]
```
