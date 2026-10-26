open System

let docFormatCheckerAndConverter (conversionFunction: string -> string) (validFormats: string list) =
    fun (filename: string) content ->
        let suffix = filename.Split('.')[1]

        if not (List.contains suffix validFormats) then
            failwith "invalid file format"

        conversionFunction content


let capitalizeContent (content: string) = content.ToUpper()

let reverseContent (content: string) = String(Array.rev (content.ToCharArray()))
