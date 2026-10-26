type ParseResult =
    | Parsed of docName: string * text: string
    | ParseError of docName: string * err: string

// Don't touch above this line


let parseDocument docName content =
    if content = "" then
        ParseError(docName, "no content")
    else
        Parsed(docName, content)


let displayParseResult result =
    match result with
    | Parsed(docName, text) -> $"Parsed {docName}: {text.Length} characters"
    | ParseError(docName, err) -> $"Failed {docName}: {err}"
