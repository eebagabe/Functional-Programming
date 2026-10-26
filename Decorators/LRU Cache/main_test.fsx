#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("aibohphobia", true)
  ("eve", true)
  ("level", true)
  ("", true)
  ("tat", true)
  ("rotator", true)
  ("potato", false)
  ("a", true)
  ("apple", false)
  ("redivider", true)
  ("divide", false)
  ("kayak", true)
  ("river", false)
  ("no", false) ]
|> List.map (fun (word, expected) -> check $"Input: '{word}'" expected (isPalindrome word))
|> report
