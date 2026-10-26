#load "../../TestRunner.fsx"
#load "main.fsx"

open TestRunner
open Main

[ ((1920, 1080),
   (800, 600),
   [ ((2560, 1440), (1920, 1080))
     ((500, 400), (800, 600))
     ((1600, 1000), (1600, 1000))
     ((800, 600), (800, 600))
     ((1920, 1080), (1920, 1080)) ],
   None)
  ((1200, 800), (1600, 800), [], Some "minimum size cannot exceed maximum size")
  ((1600, 800), (1200, 1200), [], Some "minimum size cannot exceed maximum size")
  ((1600, 1200), (1200, 800), [ ((1601, 799), (1600, 800)); ((1199, 1201), (1200, 1200)) ], None)
  ((600, 600), (600, 600), [ ((601, 601), (600, 600)); ((599, 599), (600, 600)) ], None)
  ((100, 100), (0, 0), [ ((200, 200), (100, 100)); ((0, 0), (0, 0)) ], None) ]
|> List.collect (fun (maxSize, minSize, images, expectedError) ->
    let label = $"Max size: {maxSize}, Min size: {minSize}"

    match attempt (fun () -> newResizer maxSize minSize) with
    | Error err -> [ check label expectedError (Some err) ]
    | Ok _ when expectedError.IsSome -> [ check label expectedError None ]
    | Ok resize -> images |> List.map (fun (size, expected) -> check $"{label}, Image size: {size}" expected (resize size)))
|> report
