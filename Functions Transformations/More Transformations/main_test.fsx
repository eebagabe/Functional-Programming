#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let validFormats = [ "txt"; "md"; "doc" ]

[ ("capitalizeContent",
   capitalizeContent,
   "sample.txt",
   "I really don't feel like screaming today.",
   Ok "I REALLY DON'T FEEL LIKE SCREAMING TODAY.")
  ("reverseContent",
   reverseContent,
   "testing.doc",
   "This is probably how they write in the red room in Twin Peaks...",
   Ok "...skaeP niwT ni moor der eht ni etirw yeht woh ylbaborp si sihT")
  ("capitalizeContent",
   capitalizeContent,
   "test.docx",
   "Okay actually I do feel like screaming today.",
   Error "invalid file format")
  ("reverseContent", reverseContent, "end.ppt", "Cherry pie and coffee anyone?", Error "invalid file format")
  ("capitalizeContent",
   capitalizeContent,
   "sample.doc",
   "I really do feel like eating today.",
   Ok "I REALLY DO FEEL LIKE EATING TODAY.")
  ("reverseContent",
   reverseContent,
   "testing.md",
   "The owls are not what they seem.",
   Ok ".mees yeht tahw ton era slwo ehT") ]
|> List.map (fun (name, conversion, filename, content, expected) ->
    let result =
        attempt (fun () -> docFormatCheckerAndConverter conversion validFormats filename content)

    check $"conversion_func: {name}, filename: {filename}" expected result)
|> report
