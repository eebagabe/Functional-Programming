#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ([ "Welcome to the jungle"; "We've got fun and games"; "We've got everything you want honey" ], 15)
  ([ "We are the champions my friends"; "And we'll keep on fighting till the end" ], 14)
  ([ "I've got another confession to make"
     "I'm your fool"
     "Everyone's got their chains to break"
     "Holdin' you" ],
   17) ]
|> List.map (fun (docs, expected) ->
    let aggregator = wordCountAggregator ()
    check $"Input: %A{docs}" expected (docs |> List.map aggregator |> List.last))
|> report
