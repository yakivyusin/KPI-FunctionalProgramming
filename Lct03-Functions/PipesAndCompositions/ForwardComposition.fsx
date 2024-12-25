let add x y = x + y
let timesBy x y = x * y
let inc = add 1
let square x = x * x
let double = timesBy 2
let toString x = x.ToString()

let stringifyDoubledSquare = square >> double >> toString

printfn "2 * 16^2 = %s" <| stringifyDoubledSquare 16
