module SaturnApp.WeatherForecast

open System

type T = { Date: DateTime; TemperatureC: int; Summary: string } with
    member this.TemperatureF =
        32.0 + (float this.TemperatureC / 0.5556)

let getAll =
    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
    let rng = Random()
    fun count (startDate: DateTime) ->
        [
            for index in 0..count ->
                { Date = startDate.AddDays(index)
                  TemperatureC = rng.Next(-20, 55)
                  Summary = rng.GetItems(summaries, 1).[0] }
        ]

let getForDay = getAll 0
let getForWeek = getAll 6

let add (forecast: T) = forecast
