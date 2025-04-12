namespace AspNetCoreControllers.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open AspNetCoreControllers

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger: ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet>]
    member _.Get() =
        logger.LogInformation("GET request")
        let rng = Random()
        [
            for index in 0..4 ->
                { Date = DateTime.Now.AddDays(index)
                  TemperatureC = rng.Next(-20, 55)
                  Summary = rng.GetItems(summaries, 1).[0] }
        ]
