type DocTree = DocTree of Map<int, DocTree>

let countNestedLevels nestedDocuments targetDocumentId =
    let rec loop (DocTree documents) level =
        documents
        |> Map.toSeq
        |> Seq.tryPick (fun (documentId, children) ->
            if documentId = targetDocumentId then Some level else loop children (level + 1))

    loop nestedDocuments 1 |> Option.defaultValue -1
