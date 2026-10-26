let argsLogger (args: obj list) (kwargs: Map<string, obj>) =
    args |> List.iteri (fun index value -> printfn "%d. %O" (index + 1) value)
    kwargs |> Map.iter (fun key value -> printfn "* %s: %O" key value)
