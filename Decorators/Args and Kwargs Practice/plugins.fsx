#load "decorators.fsx"

open Decorators

let configureBackups =
    configurePluginDecorator (fun kwargs ->
        let get key fallback = kwargs |> Map.tryFind key |> Option.defaultValue fallback
        Map [ "path", get "path" "~/backups"; "prefix", get "prefix" "copy_"; "extension", get "extension" ".txt" ])


let configureLogin =
    configurePluginDecorator (fun kwargs ->
        Map [ "user", Map.tryFind "user" kwargs
              "password", Map.tryFind "password" kwargs
              "token", Map.tryFind "token" kwargs ])
