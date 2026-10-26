#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let hovercraft = "My hovercraft is full of eels"
let lumberjack = "He's a lumberjack and he's okay. He sleeps all night and he works all day"
let spam = "Spam, spam, spam, spam, spam, spam, baked beans, spam, spam, and spam"
let incorrect = "This doc should 'incorrectly' have 9999 words to test that the memoization is working"

[ (hovercraft, Map [ hovercraft, 6; lumberjack, 15 ], (6, Map [ hovercraft, 6; lumberjack, 15 ]))
  (spam, Map.empty, (12, Map [ spam, 12 ]))
  ("This is an ex-parrot",
   Map [ "This parrot is no more", 5 ],
   (4, Map [ "This parrot is no more", 5; "This is an ex-parrot", 4 ]))
  (incorrect, Map [ hovercraft, 6; incorrect, 9999 ], (9999, Map [ hovercraft, 6; incorrect, 9999 ])) ]
|> List.map (fun (document, memos, expected) -> check $"Input document: {document}" expected (wordCountMemo document memos))
|> report
