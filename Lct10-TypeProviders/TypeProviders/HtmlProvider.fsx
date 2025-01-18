System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

#r "nuget: FSharp.Data"

open FSharp.Data

type WikiPage = HtmlProvider<"https://en.wikipedia.org/wiki/List_of_countries_by_GDP_(nominal)">

WikiPage.GetSample().Tables.Table.Rows
|> Array.map (fun x -> (x.``Country/Territory``, x.``United Nations[15] - Estimate``))
|> Array.filter (fun (country, _) -> country <> "World")
|> Array.iter (printfn "%A")
