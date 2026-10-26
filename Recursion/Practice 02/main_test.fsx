#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let node children = DocTree(Map children)

let tree =
    node
        [ 1,
          node
              [ 2, node [ 3, node []; 4, node [ 5, node [] ] ]
                6, node []
                7, node [ 8, node [ 9, node [ 10, node [] ] ] ] ] ]

[ (tree, 2, 2); (tree, 9, 4); (node [], 1, -1); (tree, 5, 4); (tree, 20, -1) ]
|> List.map (fun (input, documentId, expected) ->
    check $"Input document id: {documentId}" expected (countNestedLevels input documentId))
|> report
