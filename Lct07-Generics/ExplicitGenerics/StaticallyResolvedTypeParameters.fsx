let inline getLength<'T when 'T : (member Length: int with get)> (x: 'T) = x.Length

getLength "Hello, World" |> printfn "%i"
getLength (System.Text.StringBuilder()) |> printfn "%i"
getLength (System.Collections.BitArray(10)) |> printfn "%i"
// fail: getLength (System.Collections.ArrayList()) |> printfn "%i"

let inline add x y = x + y

add 1 2 |> printfn "%A"
add 1.0 2.0 |> printfn "%A"
add "1" "2" |> printfn "%A"
// fail: add (System.Object()) (System.Object()) |> printfn "%A"

let inline double<'T when 'T: (member Double: unit -> 'T)> (x: 'T) = x.Double()    
let inline zero<'T when 'T : (static member Zero: unit -> 'T)> () = 'T.Zero()

type Record = { Number: int } with
    member this.Double() = { Number = this.Number * 2 }
    static member Zero() = { Number = 0 }

let r = zero<Record> ()
let doubleR = double r
