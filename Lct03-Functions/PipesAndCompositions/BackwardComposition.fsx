let isEven x = x % 2 = 0

printfn "2 is odd: %b" (2 |> isEven |> not)
printfn "3 is odd: %b" (3 |> (not << isEven))

let isOdd1 = isEven >> not
let isOdd2 = not << isEven
