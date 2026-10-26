let createMarkdownImage (altText: string) (url: string) (title: string option) =
    let escapedUrl = url.Replace("(", "%28").Replace(")", "%29")

    match title with
    | Some title when title <> "" -> $"![{altText}]({escapedUrl} \"{title}\")"
    | _ -> $"![{altText}]({escapedUrl})"
