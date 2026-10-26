module TestRunner

let check (label: string) expected actual =
    printfn "---------------------------------"
    printfn "%s" label
    printfn "Expected: %A" expected
    printfn "Actual:   %A" actual
    let passed = expected = actual
    printfn "%s" (if passed then "Pass" else "Fail")
    passed

let attempt f =
    try Ok(f ()) with e -> Error e.Message

let report (results: bool list) =
    let passed = results |> List.filter id |> List.length
    let failed = results.Length - passed
    printfn "%s" (if failed = 0 then "============= PASS ==============" else "============= FAIL ==============")
    printfn "%d passed, %d failed" passed failed
    exit (if failed = 0 then 0 else 1)
