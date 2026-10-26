# Memoization

At its core, [memoization](https://en.wikipedia.org/wiki/Memoization) is just [caching](<https://en.wikipedia.org/wiki/Cache_(computing)>) (storing a copy of) the result of a computation so that we don't have to compute it again in the future.

For example, take this simple function:

```fsharp
let add x y = x + y
```

A call to `add 5 7` will *always* evaluate to `12`. So, if you think about it, once we know that `add 5 7` can be replaced with `12`, we can just store the value `12` somewhere in memory so that we don't have to do the addition operation again in the future. Then, if we need to `add 5 7` again, we can just look up the value `12` instead of doing a (potentially expensive) CPU operation.

The slower and more complex the function, the more memoization can help speed things up.

It's pronounced "memOization", not "memORization". This confused me for quite a while in college, I thought my professor just didn't speak goodly...

## Assignment

Counting the words in a document can be slow, so we want to *memoize* it.

Complete the `wordCountMemo` function. It takes two inputs:

1. A `document` string.
2. A `memos` map, `Map<string, int>`. The keys are full document strings, and the values are the word count of the document.

It should return a tuple with two values:

1. The word count of the given document
2. An updated `memos` map.

F# maps are immutable, so there's nothing to copy: adding a key returns a new map. Here are the steps to follow:

1. [ ] If the document is in the `memos` map ([`Map.tryFind`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#tryFind)), just return the associated word count and `memos` unchanged. No need to recompute the word count.
2. [ ] Otherwise, use the provided `wordCount` function to count the words in the given `document`.
3. [ ] Return the word count and `memos` with the new entry added ([`Map.add`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#add)).
