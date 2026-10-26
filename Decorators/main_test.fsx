#load "../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ (("Welcome to the jungle", "txt"),
   ("Processing doc: 'Welcome to the jungle'. File Type: txt", Map [ "txt", 1 ]))
  (("We've got fun and games", "txt"),
   ("Processing doc: 'We've got fun and games'. File Type: txt", Map [ "txt", 2 ]))
  (("We've got *everything* you want honey", "md"),
   ("Processing doc: 'We've got *everything* you want honey'. File Type: md", Map [ "txt", 2; "md", 1 ]))
  (("We are the champions my friends", "docx"),
   ("Processing doc: 'We are the champions my friends'. File Type: docx", Map [ "txt", 2; "md", 1; "docx", 1 ]))
  (("print('hello world')", "py"),
   ("Processing doc: 'print('hello world')'. File Type: py", Map [ "txt", 2; "md", 1; "docx", 1; "py", 1 ])) ]
|> List.map (fun ((doc, fileType), expected) -> check $"Inputs: {doc}, {fileType}" expected (processDoc doc fileType))
|> report
