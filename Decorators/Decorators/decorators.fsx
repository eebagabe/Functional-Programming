let convertMdToTxt (doc: string) =
    doc.Split('\n') |> Array.map (fun line -> line.TrimStart('#', ' ')) |> String.concat "\n"


let markdownToTextDecorator (func: string list -> string) =
    fun (args: string list) -> func (List.map convertMdToTxt args)
