namespace AspNetCoreControllers

open System

type WeatherForecast = { Date: DateTime; TemperatureC: int; Summary: string } with
    member this.TemperatureF =
        32.0 + (float this.TemperatureC / 0.5556)
