type MaybeParsed =
    | Parsed of docName: string * text: string
    | ParseError of docName: string * err: string
