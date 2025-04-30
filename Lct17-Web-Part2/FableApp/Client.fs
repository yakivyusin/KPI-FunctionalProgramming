module Client

open Browser
open SaturnApp
open Thoth.Json

(*
    Стандартний приклад із шаблону.
    promise - обчислювальний вираз як async та task.
*)
promise {
    let header = document.getElementById "header"
    header.innerText <- "loading..."
    do! Promise.sleep 1000
    let! response = Fetch.fetch "/api/hello" []
    let! text = response.text()
    header.innerText <- text
} |> Promise.start

(*
    Далі - приклад роботи з JSON API.
*)

let createRowForWeatherForecast (forecast: WeatherForecast.T) =
    let row = document.createElement "tr"

    let cell = document.createElement "td"
    cell.innerText <- forecast.Date.ToShortDateString()
    row.appendChild cell |> ignore

    let cell = document.createElement "td"
    cell.innerText <- forecast.TemperatureC.ToString()
    row.appendChild cell |> ignore

    let cell = document.createElement "td"
    cell.innerText <- forecast.Summary
    row.appendChild cell |> ignore

    row

let appendRowToTable =
    let header = document.getElementById "header"
    let table = document.createElement "table"
    header.insertAdjacentElement ("afterend", table) |> ignore
    fun row ->
        table.appendChild row |> ignore

(*
    Замість обчислювального виразу можемо використовувати конвеєрний стиль із map/bind.
*)
let loadForecasts () =
    Fetch.fetch "/api/weatherforecasts" []
    |> Promise.bind _.text()
    |> Promise.map (fun txt -> Decode.Auto.fromString<WeatherForecast.T list> (txt, caseStrategy = CamelCase))
    |> Promise.map (Result.map (List.map createRowForWeatherForecast))
    |> Promise.map (Result.map (List.iter appendRowToTable))

loadForecasts () |> ignore
