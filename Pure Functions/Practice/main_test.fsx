#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let addFormatCmd = (addCustomCommand defaultCommands "add_format" addFormat)["add_format"]
let saveDocumentCmd = (addCustomCommand defaultCommands "save_document" saveDocument)["save_document"]
let addLineBreakCmd = (addCustomCommand defaultCommands "add_line_break" addLineBreak)["add_line_break"]

let formats =
    [ ([ "rtf"; "csv" ], [ "txt"; "md"; "html"; "rtf"; "csv" ])
      ([ "doc"; "docx"; "pdf" ], [ "txt"; "md"; "html"; "doc"; "docx"; "pdf" ]) ]
    |> List.map (fun (inputs, expected) ->
        check $"add_format %A{inputs}" expected (List.fold addFormatCmd defaultFormats inputs))

let documents =
    [ ([ ("My_Princess_Diaries.txt", "I can't be a princess!")
         ("The_Devil_Wears_Boots.md", "Please, bore someone else with your questions.") ])
      ([ ("Function_Club.txt", "The types you own end up owning you"); ("Shrek.doc", "Functions are like onions.") ]) ]
    |> List.map (fun inputs ->
        let result = inputs |> List.fold (fun docs (name, doc) -> saveDocumentCmd docs name doc) savedDocuments
        check $"save_document %A{inputs}" (Map inputs) result)

let lineBreaks =
    [ ("It's not you, it's me.", "It's not you, it's me.\n\n"); ("Go be free.", "Go be free.\n\n") ]
    |> List.map (fun (input, expected) -> check $"add_line_break '{input}'" expected (addLineBreakCmd input))

report (formats @ documents @ lineBreaks)
