#load "../../TestRunner.fsx"
#load "formatters.fsx"

open TestRunner
open Formatters

[ ("concat",
   concat,
   [ "# We like to play it all"; "## Welcome to Tally Hall" ],
   "  First: We like to play it all\n  Second: Welcome to Tally Hall")
  ("formatAsEssay",
   formatAsEssay,
   [ "Why Python is Great"; "Maybe it isn't"; "## That's why Python is great!" ],
   "  Title: Why Python is Great\n  Body: Maybe it isn't\n  Conclusion: That's why Python is great!")
  ("formatAsEssay",
   formatAsEssay,
   [ "# Boots' grocery list"; "Salmon, gems, arcanum crystals"; "## Don't forget!" ],
   "  Title: Boots' grocery list\n  Body: Salmon, gems, arcanum crystals\n  Conclusion: Don't forget!") ]
|> List.map (fun (name, func, args, expected) -> check $"Function: {name} %A{args}" expected (func args))
|> report
