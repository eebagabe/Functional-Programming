let rec zipmap keys values =
    match keys, values with
    | key :: restKeys, value :: restValues -> zipmap restKeys restValues |> Map.add key value
    | _ -> Map.empty
