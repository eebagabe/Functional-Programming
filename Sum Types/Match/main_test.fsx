#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("# Hello, world!", MD, Some HTML, Ok "<h1>Hello, world!</h1>")
  ("This is plain text.", TXT, Some PDF, Ok "[PDF] This is plain text. [PDF]")
  ("<h1>Title</h1>", HTML, Some MD, Ok "# Title")
  ("Something wicked", TXT, None, Error "invalid type") ]
|> List.map (fun (content, fromFormat, toFormat, expected) ->
    check $"Converting from {fromFormat} to %A{toFormat}..." expected (attempt (fun () -> convertFormat content fromFormat toFormat)))
|> report
