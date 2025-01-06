// 'a -> unit
let print x = printfn "%A" x

print 1 // 'a = int
print "Hello World" // 'a = string
print {| First = "John"; Last = "Doe" |} // 'a = {| First: string; Last: string |}

// 'a -> 'a
let noop x = x

noop 1 |> print // 'a = int
noop "Hello World" |> print // 'a = string
noop {| First = "John"; Last = "Doe" |} |> print // 'a = {| First: string; Last: string |}

// 'a -> 'a * 'a
let pair x = (x, x)

pair 1.0 |> print // 'a = float
pair 1.0m |> print // 'a = decimal
pair 'a' |> print // 'a = char

// 'a -> 'b -> unit
let print2 x y = printfn "%A %A" x y

print2 1 1.0 // 'a = int, 'b = float
print2 1 2 // 'a = int, 'b = int
print2 "Hello" {| First = "Jane"; Last = "Smith" |} // 'a = string, 'b = {| First: string; Last: string |}

// 'a * 'b * 'c * 'd -> 'a
let fst4 (x, _, _, _) = x

fst4 (1, 1.0, 'a', "Hello") |> print // 'a = int, 'b = float, 'c = char, 'd = string

// 'a -> 'a -> System.Collections.Generic.List<'a>
let makeList x y =
    let list = System.Collections.Generic.List()
    list.Add (x)
    list.Add (y)
    list

makeList 1 2 |> print // 'a = int
makeList 1.0 2.0 |> print // 'a = float
// fail: makeList 1 2.0 |> print
