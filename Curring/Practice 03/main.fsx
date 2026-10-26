let newResizer (maxWidth, maxHeight) (minWidth, minHeight) =
    if minWidth > maxWidth || minHeight > maxHeight then
        failwith "minimum size cannot exceed maximum size"

    fun (width, height) -> (width |> min maxWidth |> max minWidth, height |> min maxHeight |> max minHeight)
