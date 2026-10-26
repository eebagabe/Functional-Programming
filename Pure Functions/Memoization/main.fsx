open System

let wordCount (document: string) =
    document.Split(Array.empty<char>, StringSplitOptions.RemoveEmptyEntries).Length


let wordCountMemo document (memos: Map<string, int>) =
    match Map.tryFind document memos with
    | Some count -> count, memos
    | None ->
        let count = wordCount document
        count, Map.add document count memos
