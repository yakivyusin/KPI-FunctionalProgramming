System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

#r "nuget: FSharp.Data"
#r "nuget: XPlot.Plotly"

open FSharp.Data
open XPlot.Plotly

(*
    XML провайдер типів, як і CSV, підтримує локальне джерело.
*)
type ExchangeRates = XmlProvider<"eurofxref-daily.xml">

ExchangeRates.GetSample() |> printfn "%A"

(*
    XML та деякі інші провайдери, крім локальних, підтримують і віддалені джерела.
    Це дозволяє нам легко писати код для дослідження та роботи з публічними API.
*)
type ExchangeRatesRemote = XmlProvider<"https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml">

ExchangeRatesRemote.GetSample().Cubes
|> Array.collect (fun x -> x.Cubes |> Array.map (fun c -> (x.Time, c.Currency, c.Rate)))
|> Array.filter (fun (_, currency, _) -> currency = "USD")
|> Array.sortBy (fun (_, _, time) -> time)
|> Array.map (fun (time, _, rate) -> (time, rate))
|> Chart.Column
|> Chart.WithLayout (Layout(title = "EUR to USD rate"))
|> Chart.Show
