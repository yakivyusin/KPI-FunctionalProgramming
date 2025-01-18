(*
    В якості прикладу використаємо API, що повертає інформацію про країни.
*)

System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

#r "nuget: FSharp.Data"
#r "nuget: XPlot.Plotly"

open FSharp.Data
open XPlot.Plotly

(*
    Використовуємо локальний файл для генерації.
    Він містить лише декілька країн для правильного виводу типів.
*)
type Countries = JsonProvider<"countries_sample.json">

(*
    А завантажуємо відповідь від API з усіма країнами.
*)
let data = Countries.Load("https://api.worldbank.org/v2/country/all?format=json&per_page=300")

let combine x y =
    match (x, y) with
    | (Some x, Some y) -> Some (x, y)
    | (_, None) | (None, _) | (None, None) -> None

data.Array
|> Array.choose (fun x -> combine x.Longitude x.Latitude)
|> Chart.Scatter
|> Chart.Show
