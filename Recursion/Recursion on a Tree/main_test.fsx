#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let dir entries = Directory(Map entries)

[ (Map [ "Documents", dir [ "Proposal.docx", File; "Report", dir [ "AnnualReport.pdf", File; "Financials.xlsx", File ] ]
         "Downloads", dir [ "picture1.jpg", File; "picture2.jpg", File ] ],
   [ "/Documents/Proposal.docx"
     "/Documents/Report/AnnualReport.pdf"
     "/Documents/Report/Financials.xlsx"
     "/Downloads/picture1.jpg"
     "/Downloads/picture2.jpg" ])
  (Map.empty, [])
  (Map [ "Work",
         dir [ "ProjectA",
               dir [ "Documentation", dir [ "README.md", File; "GUIDE.md", File ]
                     "Source", dir [ "main.py", File; "util.py", File ] ]
               "ProjectB", dir [ "Presentation.pptx", File ] ] ],
   [ "/Work/ProjectA/Documentation/GUIDE.md"
     "/Work/ProjectA/Documentation/README.md"
     "/Work/ProjectA/Source/main.py"
     "/Work/ProjectA/Source/util.py"
     "/Work/ProjectB/Presentation.pptx" ])
  (Map [ "Music", dir [ "Pop", dir [ "song1.mp3", File ]; "Classical", dir [ "Beethoven", dir [ "symphony9.mp3", File ] ] ] ],
   [ "/Music/Classical/Beethoven/symphony9.mp3"; "/Music/Pop/song1.mp3" ]) ]
|> List.map (fun (input, expected) -> check $"Input: %A{input}" expected (listFiles input |> List.sort))
|> report
