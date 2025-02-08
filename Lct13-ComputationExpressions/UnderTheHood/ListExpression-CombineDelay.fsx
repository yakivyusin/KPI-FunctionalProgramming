type ListBuilder() =
    member _.Zero () = List.empty
    member _.Yield x = List.singleton x
    member _.Combine (x, y) = List.append x y
    member _.Delay f = f()

let list = ListBuilder ()

list {
    yield "Computation expressions..."
    yield "... are magic"
} |> printfn "%A"

list {
    yield 1
    yield 2
    yield 3
    if true then
        yield 4
        yield 5
} |> printfn "%A"

(*
    Спрощений результат роботи компілятора.
*)
list.Combine(
    list.Yield("Computation expressions..."),
    list.Delay(fun () ->
        list.Yield("... are magic"))) |> printfn "%A"

list.Combine(
    list.Yield(1),
    list.Delay(fun () ->
        list.Combine(
            list.Yield(2),
            list.Delay(fun () ->
                list.Combine(
                    list.Yield(3),
                    list.Delay(fun () ->
                        if true then
                            list.Combine(
                                list.Yield(4),
                                list.Delay(fun () ->
                                    list.Yield(5)))
                        else
                            list.Zero())))))) |> printfn "%A"
