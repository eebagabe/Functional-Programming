open System

let wordCountAggregator () =
    let count = ref 0

    fun (doc: string) ->
        count.Value <- count.Value + doc.Split(Array.empty<char>, StringSplitOptions.RemoveEmptyEntries).Length
        count.Value
