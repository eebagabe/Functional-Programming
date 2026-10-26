#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ([ "The Grand Budapest Hotel"; "Fantastic Mr. Fox"; "Moonrise Kingdom" ],
   [ 8.1; 7.9; 7.8 ],
   Map [ "The Grand Budapest Hotel", 8.1; "Fantastic Mr. Fox", 7.9; "Moonrise Kingdom", 7.8 ])
  ([ "The Royal Tenenbaums"; "The Life Aquatic with Steve Zissou"; "Isle of Dogs" ],
   [ 7.6; 7.3; 7.9 ],
   Map [ "The Royal Tenenbaums", 7.6; "The Life Aquatic with Steve Zissou", 7.3; "Isle of Dogs", 7.9 ])
  ([], [], Map.empty)
  ([ "" ], [], Map.empty)
  ([], [ 0.0 ], Map.empty)
  ([ "Rushmore"; "The Darjeeling Limited"; "The French Dispatch"; "The Wonderful Story of Henry Sugar and Three More" ],
   [ 7.7; 7.2; 7.4 ],
   Map [ "Rushmore", 7.7; "The Darjeeling Limited", 7.2; "The French Dispatch", 7.4 ])
  ([ "Bottle Rocket"; "Asteroid City"; "The Grand Budapest Hotel" ],
   [ 7.0; 7.6; 8.1; 0.0 ],
   Map [ "Bottle Rocket", 7.0; "Asteroid City", 7.6; "The Grand Budapest Hotel", 8.1 ]) ]
|> List.map (fun (keys, values, expected) -> check $"Inputs: %A{keys}, %A{values}" expected (zipmap keys values))
|> report
