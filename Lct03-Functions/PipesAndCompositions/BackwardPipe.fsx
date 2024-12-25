let add x y = x + y
let timesBy x y = x * y
let inc = add 1
let square x = x * x
let double = timesBy 2
let toString x = x.ToString()

printfn "16^2 = %i" <| square 16

let answer = 16
            |> add 5
            |> timesBy <| square 2
            |> inc

printfn "(16 + 5) * 2^2 + 1 = %i" answer
