#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ (Map [ "h1", Map [ "color", "yellow" ]; "body", Map [ "background-color", "black"; "color", "white" ] ],
   [ ("h1", "color", "#CC00FF"); ("body", "background-color", "#696969") ],
   Map [ "h1", Map [ "color", "#CC00FF" ]; "body", Map [ "background-color", "#696969"; "color", "white" ] ])
  (Map.empty, [ ("p", "font-size", "16px") ], Map [ "p", Map [ "font-size", "16px" ] ])
  (Map [ ".container", Map [ "max-width", "1200px"; "margin", "0 auto"; "padding", "0 20px" ] ],
   [ (".container", "max-width", "1450px"); (".container", "color", "#660099") ],
   Map [ ".container", Map [ "max-width", "1450px"; "margin", "0 auto"; "padding", "0 20px"; "color", "#660099" ] ]) ]
|> List.map (fun (initialStyles, stylesToAdd, expected) ->
    let addStyle = cssStyles initialStyles
    let result = stylesToAdd |> List.fold (fun _ (s, p, v) -> addStyle s p v) initialStyles
    check $"Initial styles: %A{initialStyles}" expected result)
|> report
