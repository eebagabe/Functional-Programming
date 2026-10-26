#load "../../TestRunner.fsx"
#load "main.fsx"

open System
open TestRunner
open Main

[ ("PDF", true); ("TXT", true); ("DOCX", true); ("MD", true); ("HTML", true); ("Invalid", false) ]
|> List.map (fun (name, isValid) -> check $"Checking value: Doctype.{name}" isValid (Enum.IsDefined(typeof<Doctype>, name)))
|> report
