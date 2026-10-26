#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("Either that wallpaper goes, or I do.", "wallpaper")
  ("Then I die happy", "happy")
  ("Et tu, Brute?", "Brute?")
  ("", "")
  (" ", "")
  ("Let us cross over the river and rest under the shade of the trees", "cross") ]
|> List.map (fun (input, expected) -> check $"Input: '{input}'" expected (findLongestWord input))
|> report
