## Assignment

You're responsible for a module in Doc2Doc that can scan a file system (represented in our code as nested maps) and create a list of the filenames.

Each entry in a directory is either a file or a child directory:

```fsharp
type Entry =
    | File
    | Directory of Map<string, Entry>
```

Complete the recursive `listFiles` function. It accepts one argument:

- `parentDirectory`: A `Map<string, Entry>` representing the root directory.

It should return a list of all filepaths in the `parentDirectory`, each starting with a slash (e.g. `/dir1/dir2/filename.txt`).

## Steps

1. [ ] Define an inner `let rec` function that takes a directory map and the `currentFilepath` (start it with `""`).
2. [ ] Go through every `(name, entry)` pair of the directory:
   1. [ ] Create a new file path by concatenating a slash `/` and the name to the end of the `currentFilepath`.
   2. [ ] If the entry is `File`, the result is a list with only the new file path.
   3. [ ] Otherwise, the entry is a `Directory`. Recursively call the inner function with the child directory and the new file path.
3. [ ] Combine all the resulting lists into one and return it. [`List.collect`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#collect) maps and concatenates in one step.

Example `parentDirectory`:

```fsharp
Map [ "Documents",
      Directory(
          Map [ "Proposal.docx", File
                "Receipts",
                Directory(
                    Map [ "January", Directory(Map [ "receipt1.txt", File; "receipt2.txt", File ])
                          "February", Directory(Map [ "receipt3.txt", File ]) ]
                ) ]
      ) ]
```

Resulting list of file paths (sorted):

```fsharp
[ "/Documents/Proposal.docx"
  "/Documents/Receipts/February/receipt3.txt"
  "/Documents/Receipts/January/receipt1.txt"
  "/Documents/Receipts/January/receipt2.txt" ]
```

## Tips

- What's the base case? It looks a bit different than before, but it's just when an entry is a `File` because in that case we don't have any more directories to explore.
- You don't need a loop at all: `Map.toList` gives you the entries, and recursion handles the nesting (the number of nested maps we don't know in advance).
- Use `@` or `List.collect` to join lists:

```fsharp
let items = [ "six-string lute"; "petrified dragon egg"; "the only ring" ]
items @ [ "philosopher's stone"; "invisibility cloak"; "moistened scimitar" ]
// ["six-string lute"; "petrified dragon egg"; "the only ring"; "philosopher's stone"; "invisibility cloak"; "moistened scimitar"]
```
