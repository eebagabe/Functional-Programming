type Entry =
    | File
    | Directory of Map<string, Entry>

let listFiles (parentDirectory: Map<string, Entry>) =
    let rec loop directory currentFilepath =
        directory
        |> Map.toList
        |> List.collect (fun (name, entry) ->
            let filepath = currentFilepath + "/" + name

            match entry with
            | File -> [ filepath ]
            | Directory children -> loop children filepath)

    loop parentDirectory ""
