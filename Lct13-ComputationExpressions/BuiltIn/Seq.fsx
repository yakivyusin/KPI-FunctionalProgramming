let weekdays includeWeekends = seq {
    yield "Monday"
    yield "Tuesday"
    yield "Wednesday"
    yield "Thursday"
    yield "Friday"
    if includeWeekends then
        yield "Saturday"
        yield "Sunday"
}

(*
    Або, опустивши yield:

    let weekdays includeWeekends = seq {
        "Monday"
        "Tuesday"
        "Wednesday"
        "Thursday"
        "Friday"
        if includeWeekends then
            "Saturday"
            "Sunday"
    }
*)

weekdays false |> Seq.iter (printfn "%s")
weekdays true |> Seq.iter (printfn "%s")

(*
    Без yield! це буде Seq<Seq<string>>, як і у випадку return! для async/task.
*)
let workMonth = seq {
    for i in 0..3 do
        yield! weekdays false
}

workMonth |> Seq.iteri (fun i x -> printfn "W: %i, %s" (i / 5) x)
