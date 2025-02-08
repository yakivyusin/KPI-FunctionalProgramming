type ListBuilder() =
    member _.Zero () = List.empty
    member _.Yield x = List.singleton x
    member _.Combine (x, y) = List.append x y
    member _.Delay f = f()
    member _.YieldFrom l = l
    member _.For (l, f) = List.collect f <| Seq.toList l

let list = ListBuilder ()

list {
    for i in 1..10 do
        yield i
} |> printfn "%A"

list {
    for i in 1..10 do
        yield! [i; i * i]
} |> printfn "%A"

(*
    Спрощений результат роботи компілятора.
*)
list.For([1..10], list.Yield) |> printfn "%A"
list.For([1..10], fun i -> list.YieldFrom([i; i * i])) |> printfn "%A"
