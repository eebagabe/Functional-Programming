#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("why_fp.txt",
   "Because functions are easier to test",
   Parsed("why_fp.txt", "Because functions are easier to test"),
   "Parsed why_fp.txt: 36 characters")
  ("why_fp.md", "", ParseError("why_fp.md", "no content"), "Failed why_fp.md: no content")
  ("functional-patterns.txt",
   "Unions make alternative states explicit",
   Parsed("functional-patterns.txt", "Unions make alternative states explicit"),
   "Parsed functional-patterns.txt: 39 characters")
  ("empty.md", "", ParseError("empty.md", "no content"), "Failed empty.md: no content") ]
|> List.map (fun (docName, content, expectedResult, expectedMessage) ->
    let result = parseDocument docName content
    check $"Parsing document: {docName}" (expectedResult, expectedMessage) (result, displayParseResult result))
|> report
