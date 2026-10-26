#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

let first = "I'm bad, and that's good. I will never be good, and that's not bad.."
let second = "There's no place like home.. but sometimes, it's nice to get away... and explore...."

[ ("replaceBad", replaceBad, "replaceEllipsis", replaceEllipsis,
   [ (first, None, Ok "I'm good, and that's good. I will never be good, and that's not good..")
     (first, Some "--one", Ok "I'm good, and that's good. I will never be good, and that's not good..")
     (first, Some "--two", Ok "I'm bad, and that's good. I will never be good, and that's not bad...")
     (first, Some "--three", Ok "I'm good, and that's good. I will never be good, and that's not good...") ])
  ("replaceEllipsis", replaceEllipsis, "fixEllipsis", fixEllipsis,
   [ (second, None, Ok "There's no place like home... but sometimes, it's nice to get away.... and explore......")
     (second, Some "--one", Ok "There's no place like home... but sometimes, it's nice to get away.... and explore......")
     (second, Some "--two", Ok "There's no place like home.. but sometimes, it's nice to get away... and explore...")
     (second, Some "--three", Ok "There's no place like home... but sometimes, it's nice to get away... and explore.....")
     (second, Some "", Error "invalid option") ]) ]
|> List.collect (fun (nameOne, filterOne, nameTwo, filterTwo, cases) ->
    let filterCmd = getFilterCmd filterOne filterTwo

    cases
    |> List.map (fun (content, option, expected) ->
        check $"{nameOne} and {nameTwo}, option: %A{option}" expected (attempt (fun () -> filterCmd content option))))
|> report
