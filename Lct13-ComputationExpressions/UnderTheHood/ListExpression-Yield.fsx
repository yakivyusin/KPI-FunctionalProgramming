type ListBuilder() =
    member _.Zero () = List.empty
    member _.Yield x = List.singleton x

let list = ListBuilder ()

list {
    yield "This is magic"
} |> printfn "%A"

list {
    yield 1
} |> printfn "%A"
