type ListBuilder() =
    member _.Zero () = List.empty
    member _.Yield x = List.singleton x
    member _.Combine (x, y) = List.append x y
    member _.Delay f = f()
    member _.YieldFrom l = l

let list = ListBuilder ()

list {
    yield "Computation expressions..."
    yield "... are magic"
    yield! ["!"; "!"; "!"]
    yield " (c)"
} |> printfn "%A"

list {
    yield 1
    yield 2
    yield 3
    if true then
        yield 4
        yield 5
    yield! [6; 7; 8]
} |> printfn "%A"


