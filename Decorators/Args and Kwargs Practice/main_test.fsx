#load "../../TestRunner.fsx"
#load "plugins.fsx"

open TestRunner
open Plugins

let backups =
    [ ([ "path", "~/documents"; "extension", ".md" ],
       Map [ "path", "~/documents"; "prefix", "copy_"; "extension", ".md" ])
      ([ "path", "~/workspace/backups"; "prefix", "backup_" ],
       Map [ "path", "~/workspace/backups"; "prefix", "backup_"; "extension", ".txt" ]) ]
    |> List.map (fun (args, expected) -> check $"configureBackups %A{args}" expected (configureBackups args))

let login =
    [ ([ "user", "goku_fanatic"; "password", "kakarot1989" ],
       Map [ "user", Some "goku_fanatic"; "password", Some "kakarot1989"; "token", None ])
      ([ "user", "john_q_sample"; "password", "p@$$w0rd"; "token", "a09adc-0914sf-012la9-fa3sa0-2342ra" ],
       Map [ "user", Some "john_q_sample"
             "password", Some "p@$$w0rd"
             "token", Some "a09adc-0914sf-012la9-fa3sa0-2342ra" ]) ]
    |> List.map (fun (args, expected) -> check $"configureLogin %A{args}" expected (configureLogin args))

report (backups @ login)
