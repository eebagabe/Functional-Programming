#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ([ "Dan Evans" ], [ "Charlie Prince" ], [ "Dan Evans"; "Charlie Prince" ])
  ([ "Dan Evans"; "Ben Wade" ], [ "Alice Evans" ], [ "Dan Evans"; "Ben Wade"; "Alice Evans" ])
  ([ "Dan Evans"; "Ben Wade"; "Alice Evans" ],
   [ "Doc Potter"; "Butterfield" ],
   [ "Dan Evans"; "Ben Wade"; "Alice Evans"; "Doc Potter"; "Butterfield" ])
  ([ "Dan Evans"; "Ben Wade"; "Alice Evans" ], [], [ "Dan Evans"; "Ben Wade"; "Alice Evans" ])
  ([], [ "William Evans" ], [ "William Evans" ])
  ([ "Dan Evans"; "Ben Wade" ],
   [ "Charlie Prince"; "Butterfield" ],
   [ "Dan Evans"; "Ben Wade"; "Charlie Prince"; "Butterfield" ]) ]
|> List.map (fun (initialDocs, docsToAdd, expected) ->
    let addDoc = newCollection initialDocs
    let result = docsToAdd |> List.fold (fun _ doc -> addDoc doc) initialDocs
    check $"Initial: %A{initialDocs} Add: %A{docsToAdd}" expected result)
|> report
