#load "logger.fsx"

open Logger

let test (args: obj list) (kwargs: (string * obj) list) =
    argsLogger args (Map kwargs)
    printfn "========================================"

printfn "--- Test 1: Mix of args & kwargs -------"
test [ "Good"; "riddance" ] [ "date_str", "01/01/2023" ]

printfn "--- Test 2: Only kwargs ----------------"
test [] [ "message", "Hello World"; "to_delete", "l" ]

printfn "--- Test 3: Only args ------------------"
test [ "two"; "star-crossed"; "lovers" ] []

printfn "--- Test 4: Mix of args & kwargs -------"
test [ "hi"; true ] [ "f_name", "Lane"; "l_name", "Wagner"; "age", 28 ]
