# Closure Practice

Remember, a [closure](https://en.wikipedia.org/wiki/Closure_\(computer_programming\)) is a function that retains the state of its environment. That makes it useful for tracking data as it changes over time, but it can come at the cost of understandability.

F# lists are immutable: appending with `@` builds a _new_ list and leaves the original untouched. So the closure doesn't need to copy `initialDocs`; it only needs a `ref` cell to remember which list is the current one.

## Assignment

Complete the `newCollection` function. It takes as input:

- `initialDocs`: a list of strings.

It returns a function that:

1. [ ] Accepts a string
2. [ ] _Closes over_ the current list, starting from `initialDocs`.
3. [ ] Appends the input to the closed-over list
4. [ ] Returns the updated list.

The original `initialDocs` list must stay the same!

## Example Usage

```fsharp
let myCollection = newCollection [ "doc1"; "doc2"; "doc3" ]
printfn "%A" (myCollection "doc4")
// ["doc1"; "doc2"; "doc3"; "doc4"]
printfn "%A" (myCollection "doc5")
// ["doc1"; "doc2"; "doc3"; "doc4"; "doc5"]
```
