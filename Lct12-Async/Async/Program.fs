open FSharp.Data

let asyncTryGetTitle url = async {
    let! html = HtmlDocument.AsyncLoad url
    return html.Descendants "title"
           |> Seq.map HtmlNodeExtensions.InnerText
           |> Seq.tryHead
}

[<EntryPoint>]
let main args =
    args
    |> Seq.map asyncTryGetTitle
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.choose (fun x -> x)
    |> Array.iter (printfn "%s")
    0
