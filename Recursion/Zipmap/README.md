- A recursive function is basically a function that calls itself. In F#, it must be declared with `let rec`.

```fsharp
let rec sumNums nums =
    match nums with
    | [] -> 0
    | first :: rest -> first + sumNums rest

printfn "%d" (sumNums [ 1; 2; 3; 4; 5 ]) // 15
```

## Assignment

Within Doc2Doc we need to map certain properties from one document to properties of another document. Complete the recursive `zipmap` function.

It takes two lists as input and returns a [`Map`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html) where the first list provides the *keys* and the second list provides the *values*.

Example usage:

```fsharp
let zipped =
    zipmap
        [ "Avatar: The Last Airbender"; "Avatar (in Papyrus font)"; "The Last Airbender (Live Action)" ]
        [ 9.9; 6.1; 2.1 ]

printfn "%A" zipped
// map
//   [("Avatar (in Papyrus font)", 6.1); ("Avatar: The Last Airbender", 9.9);
//    ("The Last Airbender (Live Action)", 2.1)]
```

Pseudocode:

1. If either the `keys` or `values` list is empty, return an empty map (base case). This takes care of creating a map.
2. Recursively call `zipmap` on all but the first elements from `keys` and `values`
3. Add the first element of `keys` to the resulting map, and set its value to the first element in `values`
4. Return the updated map

Matching both lists at once, `match keys, values with`, covers the base case and the recursive case in two branches.
