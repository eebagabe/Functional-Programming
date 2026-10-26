let fileTypeAggregator (funcToDecorate: string -> string -> string) =
    // file_type -> count
    let counts = ref Map.empty

    fun doc fileType ->
        counts.Value <- counts.Value |> Map.change fileType (fun count -> Some(defaultArg count 0 + 1))
        funcToDecorate doc fileType, counts.Value


// don't touch above this line

let processDoc =
    fileTypeAggregator (fun doc fileType -> $"Processing doc: '{doc}'. File Type: {fileType}")
