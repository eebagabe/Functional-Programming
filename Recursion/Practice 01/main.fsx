open System

let findLongestWord (document: string) =
    let rec loop words longestWord =
        match words with
        | [] -> longestWord
        | word :: rest -> loop rest (if String.length word > String.length longestWord then word else longestWord)

    loop (document.Split(Array.empty<char>, StringSplitOptions.RemoveEmptyEntries) |> List.ofArray) ""
