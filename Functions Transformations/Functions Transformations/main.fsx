let getLogger (formatter: string -> string -> string) =
    fun first second -> printfn "%s" (formatter first second)


// Don't edit below this line

let test first errors formatter =
    printfn "Logs:"
    let logger = getLogger formatter
    errors |> List.iter (logger first)
    printfn "===================================="


let colonDelimit first second = $"{first}: {second}"

let dashDelimit first second = $"{first} - {second}"

let dbErrors = [ "out of memory"; "cpu is pegged"; "networking issue"; "invalid syntax" ]
test "Doc2Doc FATAL" dbErrors colonDelimit

let mailErrors = [ "email too large"; "non alphanumeric symbols found" ]
test "Doc2Doc WARNING" mailErrors dashDelimit
