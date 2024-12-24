let surround prefix suffix s = sprintf "%s%s%s" prefix s suffix

let roundBrackets = surround "(" ")"
let squareBrackets = surround "[" "]"
let xmlComment = surround "<!--" "-->"
let quote q = surround q q
let doubleQuote = quote "\""

printfn "%s" (roundBrackets "a")
printfn "%s" (squareBrackets "b")
printfn "%s" (xmlComment "c")
printfn "%s" (quote "\'" "d")
printfn "%s" (doubleQuote "e")
