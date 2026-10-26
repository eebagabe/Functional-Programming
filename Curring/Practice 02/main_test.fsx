#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ("seal", "https://imgur.com/oglPAXK", Some "this is a seal", "![seal](https://imgur.com/oglPAXK \"this is a seal\")")
  ("cinnamon roll",
   "https://imgur.com/a/0MyOP",
   Some "this is a cinnamon roll",
   "![cinnamon roll](https://imgur.com/a/0MyOP \"this is a cinnamon roll\")")
  ("banana", "https://imgur.com/nlArAKx", None, "![banana](https://imgur.com/nlArAKx)")
  ("not an image",
   "https://en.wikipedia.org/wiki/Variable_(computer_science)",
   Some "showing escape characters",
   "![not an image](https://en.wikipedia.org/wiki/Variable_%28computer_science%29 \"showing escape characters\")") ]
|> List.map (fun (altText, url, title, expected) ->
    check $"Alt: {altText}, URL: {url}, Title: %A{title}" expected (createMarkdownImage altText url title))
|> report
