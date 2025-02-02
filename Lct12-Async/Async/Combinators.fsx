#r "nuget: FSharp.Data"

open FSharp.Data

let asyncTryGetTitle url = async {
    printfn "Try load title of page by URL: %s" url
    let! html = HtmlDocument.AsyncLoad url
    return html.Descendants "title"
           |> Seq.map HtmlNodeExtensions.InnerText
           |> Seq.tryHead
}

let asyncGetTitle url = async {
    let! title = asyncTryGetTitle url
    return match title with
           | Some x -> x
           | None -> "No title"
}

let testData = ["https://google.com"; "https://kpi.ua"; "https://reddit.com"]

(*
    Async.Parallel: Async<'T> seq -> Async<'T array>.
    Створює асинхронну задачу, яка запустить набір задач та поверне їх результати.
*)
testData
|> Seq.map asyncGetTitle
|> Async.Parallel
|> Async.RunSynchronously
|> printfn "%A"

(*
    Також ми можемо обмежити максимальну кількість одночасно запущених задач.
*)
testData
|> Seq.map asyncGetTitle
|> fun x -> (x, 1)
|> Async.Parallel
|> Async.RunSynchronously
|> printfn "%A"

(*
    Замість Async.Parallel з максимальним ступенем паралелізму рівним 1,
    ми можемо використовувати Async.Sequantial.
*)
testData
|> Seq.map asyncGetTitle
|> Async.Sequential
|> Async.RunSynchronously
|> printfn "%A"

(*
    Async.Choice: Async<'T option> seq -> Async<'T option>.
    Створює асинхронну задачу, яка запустить набір задач та поверне результат першої, яка поверне не None.
    Якщо всі повернули None, тоді на виході теж буде None.
*)
testData
|> Seq.map asyncTryGetTitle
|> Async.Choice
|> Async.RunSynchronously
|> printfn "%A"

(*
    Async.Ignore: Async<'T> -> Async<unit>.
    Створює задачу, яка виконає іншу та відкине її результат.
    Використовується для задач Async<'T>, щоб запустити з do! або Async.Start.
*)
testData
|> Seq.map asyncGetTitle
|> Async.Parallel
|> Async.Ignore
|> Async.Start
