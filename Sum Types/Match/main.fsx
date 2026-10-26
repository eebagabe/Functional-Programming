type DocFormat =
    | PDF
    | TXT
    | MD
    | HTML

let convertFormat (content: string) fromFormat toFormat =
    match fromFormat, toFormat with
    | MD, Some HTML -> content.Replace("# ", "<h1>") + "</h1>"
    | TXT, Some PDF -> $"[PDF] {content} [PDF]"
    | HTML, Some MD -> content.Replace("<h1>", "# ").Replace("</h1>", "")
    | _ -> failwith "invalid type"
