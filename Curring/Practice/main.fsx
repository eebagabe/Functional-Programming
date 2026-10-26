open System

let linesWithSequence (char: char) (length: int) =
    let sequence = String(char, length)

    fun (doc: string) ->
        doc.Split('\n')
        |> Array.fold (fun count line -> if line.Contains sequence then count + 1 else count) 0
