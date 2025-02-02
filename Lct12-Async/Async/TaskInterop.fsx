(*
    Async.AwaitTask:
        Task -> Async<unit>
        Task<T> -> Async<T>
*)
open System.Net.Http

let asyncPageSize (url: string) = async {
    use client = new HttpClient ()
    use! response = client.GetAsync url |> Async.AwaitTask
    let! array = response.Content.ReadAsByteArrayAsync () |> Async.AwaitTask
    return Array.length array
}

asyncPageSize "https://google.com" |> Async.RunSynchronously |> printfn "%i"

(*
    Конвертації із Task у Async негативно впливають на продуктивність.
    Тому, якщо ми активно використовуємо Task-based API, краще використовувати task.
    Тим більше, що всередині task ми можемо використовувати і Async-based API (а навпаки - ні).
*)
#r "nuget: FSharp.Data"

open FSharp.Data

let tryGetTitleAsync url = task {
    printfn "Try load title of page by URL: %s" url
    let! html = HtmlDocument.AsyncLoad url
    return html.Descendants "title"
           |> Seq.map HtmlNodeExtensions.InnerText
           |> Seq.tryHead
}

tryGetTitleAsync "https://pzks.fpm.kpi.ua" |> _.Result |> printfn "%A"

(*
    Async.StartAsTask: Async<T> -> Task<T>
*)
let pageSizeAsync url = asyncPageSize url |> Async.StartAsTask

pageSizeAsync "Https://google.com" |> _.Result |> printfn "%i"
