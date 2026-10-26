#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ([ Item 1; Item 2; Items [ Item 3; Item 4 ] ], 10)
  ([ Item 5; Items [ Item 6; Item 7 ]; Items [ Items [ Item 8; Item 9 ]; Item 10 ] ], 45)
  ([], 0)
  ([ Item 1
     Items [ Item 2 ]
     Items [ Item 3; Items [ Item 4; Items [ Item 5; Items [ Item 6; Items [ Item 7; Items [ Item 8; Items [ Item 9; Items [ Item 10 ] ] ] ] ] ] ] ] ],
   55) ]
|> List.map (fun (input, expected) -> check $"Input list: %A{input}" expected (sumNestedList input))
|> report
