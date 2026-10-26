#load "../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ (12, "txt", Ok 12)
  (16, "md", Ok 32)
  (14, "html", Error "invalid doc type")
  (0, "txt", Ok 0)
  (50, "md", Ok 100) ]
|> List.map (fun (fontSize, docType, expected) ->
    check $"font_size: {fontSize}, doc_type: {docType}" expected (attempt (fun () -> convertedFontSize fontSize docType)))
|> report
