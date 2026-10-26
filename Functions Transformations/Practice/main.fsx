let getFilterCmd (filterOne: string -> string) (filterTwo: string -> string) =
    fun content option ->
        match option with
        | None
        | Some "--one" -> filterOne content
        | Some "--two" -> filterTwo content
        | Some "--three" -> content |> filterOne |> filterTwo
        | _ -> failwith "invalid option"


let replaceBad (text: string) = text.Replace("bad", "good")

let replaceEllipsis (text: string) = text.Replace("..", "...")

let fixEllipsis (text: string) = text.Replace("....", "...")
