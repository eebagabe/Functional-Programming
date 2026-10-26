type NestedItem =
    | Item of int
    | Items of NestedItem list

let rec sumNestedList (lst: NestedItem list) =
    lst
    |> List.sumBy (function
        | Item value -> value
        | Items inner -> sumNestedList inner)
