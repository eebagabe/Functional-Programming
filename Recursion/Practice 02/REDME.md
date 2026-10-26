# Recursion Practice

In Doc2Doc, we might have documents nested inside other documents, forming a kind of tree. You know how crazy `.docx` files can get...

Anyways, we want to find out how deeply nested a given document is.

## Assignment

Complete the `countNestedLevels` function. It takes a tree of nested documents and the target document id. The tree is a map from document id to its children:

```fsharp
type DocTree = DocTree of Map<int, DocTree>
```

1. [ ] Recur with an inner `let rec` function that also carries the current `level`, starting at `1`.
2. [ ] Loop over the `documentId`s in the current map (`Map.toSeq` with [`Seq.tryPick`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#tryPick) works well):
   1. [ ] If the current `documentId` matches the `targetDocumentId`, return its `level` of nesting
   2. [ ] Otherwise, recursively search the current document's children with `level + 1`
   3. [ ] If the recursive call found the `targetDocumentId`'s level, return it
3. [ ] If the `targetDocumentId` doesn't exist, the function should return `-1`

## Example

In this tree, the document with id `3` is nested 2 levels deep. Document `2` is nested 1 level deep.

```fsharp
DocTree(
    Map [ 1, DocTree(Map [ 3, DocTree Map.empty ])
          2, DocTree Map.empty ]
)
```
