## Assignment

In Doc2Doc, users can process files or *entire directories*. We need to know the *total size* of those files and directories (measured in bytes).

Due to the nested nature of directories, we represent a root directory as a list of `NestedItem` values. An `Item` is the size of a file *in* that directory, and `Items` is a nested directory:

```fsharp
type NestedItem =
    | Item of int
    | Items of NestedItem list
```

For example, here's a directory that contains 2 files at the root level, then a nested directory with its own two files:

```fsharp
let root = [ Item 1; Item 2; Items [ Item 3; Item 4 ] ]
printfn "%d" (sumNestedList root)
// 10
```

Here's a more complex example:

```
root
├── scripts.txt (5 bytes)
├── characters (dir)
│   ├── zuko.txt (6 bytes)
│   └── aang.txt (7 bytes)
└── seasons (dir)
    ├── season1 (dir)
    │   ├── the_avatar_returns.docx (8 bytes)
    │   └── the_southern_air_temple.docx (9 bytes)
    └── season2_notes.txt (10 bytes)

```

Which would be represented as:

```fsharp
let root =
    [ Item 5
      Items [ Item 6; Item 7 ]
      Items [ Items [ Item 8; Item 9 ]; Item 10 ] ]
printfn "%d" (sumNestedList root)
// 45
```

**Complete the `sumNestedList` function**. It takes a list of `NestedItem` as input and should return the total size of all files in the list. It's a recursive function (`let rec`).

Here's some pseudocode to help you get started:

1. For each item in the list:
   1. If the item is an `Item`, its value is the size.
   2. If the item is `Items`, use a recursive call to `sumNestedList` to get the size of that list.
2. Add all the sizes together and return the total.

## Tips

Lists in F# are recursive by nature, and [`List.sumBy`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#sumBy) adds up whatever value you compute for each item.

Use [pattern matching](https://learn.microsoft.com/dotnet/fsharp/language-reference/pattern-matching) to check whether an item is a file or a directory. The compiler warns you if a case is missing:

```fsharp
match item with
| Item size -> size
| Items children -> sumNestedList children
```
