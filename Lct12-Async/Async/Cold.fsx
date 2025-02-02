(*
    Провайдери типів надають асинхронні функції, що повертають Async<T>.
    Будемо використовувати HTML провайдер, але у режимі прямої роботи зі сторінкою, без генерування типу.
*)

#r "nuget: FSharp.Data"

open FSharp.Data

(*
    Всі bang'и, return у виразі async працюють аналогічно до task, тому не будемо зупинятися на кожному.
*)
let asyncTryGetTitle url = async {
    printfn "Try load title of page by URL: %s" url
    let! html = HtmlDocument.AsyncLoad url
    return html.Descendants "title"
           |> Seq.map HtmlNodeExtensions.InnerText
           |> Seq.tryHead
}

(*
    Async<T> - "холодний", він не запускається автоматично при його отриманні.
    let! та інші bang'и запускають код, тому всередині виразу async це не видно.
    Але якщо працювати із синхронного коду, то різниця очевидна.
    Тут жодного printfn до консолі не буде.
*)
asyncTryGetTitle "https://google.com"

(*
    Async.RunSynchronously: Async<'T> -> 'T.
    Запускає задачу та очікує її результату.
*)
asyncTryGetTitle "https://google.com" |> Async.RunSynchronously |> printfn "%A"

(*
    Async.Start: Async<unit> -> unit.
    Запускає задачу та НЕ очікує її результату.
*)
printfn "A"

async {
    printfn "B"
    do! Async.Sleep(1000)
    printfn "C"
} |> Async.Start

printfn "D"

(*
    Порівнюємо результат із Async.RunSynchronously:
*)
printfn "A"

async {
    printfn "B"
    do! Async.Sleep(1000)
    printfn "C"
} |> Async.RunSynchronously

printfn "D"
