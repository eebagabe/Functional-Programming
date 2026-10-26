#load "../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ Parsed("why_fp.txt", "Because we're better than everyone else")
  ParseError("why_fp.docx", "Can't handle weird windows files")
  Parsed("why_fp.md", "Because we're better than everyone else")
  ParseError("why_fp.pdf", "Can't handle weird adobe files") ]
|> List.map (fun obj ->
    match obj with
    | Parsed(docName, text) -> check $"Testing properties of {docName}..." true (text <> "" && docName <> "")
    | ParseError(docName, err) -> check $"Testing properties of {docName}..." true (err <> "" && docName <> ""))
|> report
