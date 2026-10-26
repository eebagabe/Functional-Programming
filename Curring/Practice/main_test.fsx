#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ('#', 3, "###\n@##\n$$$\n###", 2)
  ('$', 2, "$$$\n$\n***\n@@@\n$$\n$$$", 3)
  ('%', 1, "", 0)
  ('*', 3, "***\n*\n$$$$$$\nxxx\n****\n***\n***", 4) ]
|> List.map (fun (char, length, doc, expected) ->
    check $"char: {char}, length: {length}" expected (linesWithSequence char length doc))
|> report
