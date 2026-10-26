#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let customersRaw: RawCSVData =
    [ [ "Customer ID"; "Billed"; "Paid" ]; [ 1; 100; 100 ]; [ 2; 400; 99 ]; [ 3; 50; 25 ] ]

let customers =
    [ [ "Customer ID"; "Billed"; "Paid" ]; [ "1"; "100"; "100" ]; [ "2"; "400"; "99" ]; [ "3"; "50"; "25" ] ]

let customersCsv = "Customer ID,Billed,Paid\n1,100,100\n2,400,99\n3,50,25"

let cardsRaw: RawCSVData =
    [ [ "Card Name"; "Condition"; "Value" ]
      [ "Sparky Mouse"; "Fair"; 100 ]
      [ "Moist Turtle"; "Good"; 200 ]
      [ "Burning Lizard"; "Very Good"; 1000 ]
      [ "Mossy Frog"; "Poor"; 10 ] ]

let cards =
    [ [ "Card Name"; "Condition"; "Value" ]
      [ "Sparky Mouse"; "Fair"; "100" ]
      [ "Moist Turtle"; "Good"; "200" ]
      [ "Burning Lizard"; "Very Good"; "1000" ]
      [ "Mossy Frog"; "Poor"; "10" ] ]

let cardsCsv =
    "Card Name,Condition,Value\nSparky Mouse,Fair,100\nMoist Turtle,Good,200\nBurning Lizard,Very Good,1000\nMossy Frog,Poor,10"

[ (Pending customersRaw, ("Pending...", Prepared customers))
  (Processing customers, ("Processing...", Processed customersCsv))
  (Success customersCsv, ("Success!", Processed customersCsv))
  (Failure customersRaw, ("Unknown error, retrying...", Processed customersCsv))
  (Pending cardsRaw, ("Pending...", Prepared cards))
  (Processing cards, ("Processing...", Processed cardsCsv))
  (Success cardsCsv, ("Success!", Processed cardsCsv))
  (Failure cardsRaw, ("Unknown error, retrying...", Processed cardsCsv)) ]
|> List.map (fun (status, expected) -> check $"Checking: %A{status}" expected (getCsvStatus status))
|> report
