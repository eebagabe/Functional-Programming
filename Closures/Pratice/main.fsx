let newCollection (initialDocs: string list) =
    let docs = ref initialDocs

    fun doc ->
        docs.Value <- docs.Value @ [ doc ]
        docs.Value
