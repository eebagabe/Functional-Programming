let convertedFontSize fontSize docType =
    match docType with
    | "txt" -> fontSize
    | "md" -> fontSize * 2
    | "docx" -> fontSize * 3
    | _ -> failwith "invalid doc type"
