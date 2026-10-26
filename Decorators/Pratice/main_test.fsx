#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("replacer \"faith\" \"salmon\" id",
   replacer "faith" "salmon" id,
   "I find your lack of faith disturbing, young Skywalker.",
   "I find your lack of salmon disturbing, young Skywalker.")
  ("replacer \"paragraph\" \"span\" (replacer \"p>\" \"span>\" id)",
   replacer "paragraph" "span" (replacer "p>" "span>" id),
   "<p>Here is a paragraph</p>",
   "<span>Here is a span</span>")
  ("tagPre",
   tagPre,
   "<a href=\"https://www.boot.dev/blog/wiki/troubleshoot-code-editor-issues/\">link</a>",
   "<pre>&lt;a href=&quot;https://www.boot.dev/blog/wiki/troubleshoot-code-editor-issues/&quot;&gt;link&lt;/a&gt;</pre>")
  ("tagPre",
   tagPre,
   "<img src=\"https://imgur.com/a/VlMAK0B\" alt=\"mystery\">",
   "<pre>&lt;img src=&quot;https://imgur.com/a/VlMAK0B&quot; alt=&quot;mystery&quot;&gt;</pre>")
  ("tagPre",
   tagPre,
   "<p>This paragraph has <em>italic text</em></p>",
   "<pre>&lt;p&gt;This paragraph has &lt;em&gt;italic text&lt;/em&gt;&lt;/p&gt;</pre>") ]
|> List.map (fun (name, func, input, expected) -> check $"Function: {name}\nInput: {input}" expected (func input))
|> report
