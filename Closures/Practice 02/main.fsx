let cssStyles (initialStyles: Map<string, Map<string, string>>) =
    let styles = ref initialStyles

    fun selector property value ->
        let current = styles.Value |> Map.tryFind selector |> Option.defaultValue Map.empty
        styles.Value <- styles.Value |> Map.add selector (current |> Map.add property value)
        styles.Value
