open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open AspNetCoreMinimalApis
open Microsoft.Extensions.Logging

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
    app.MapGet("/weatherforecast", Func<ILoggerFactory, WeatherForecast list>(fun (loggerFactory: ILoggerFactory) ->
        let logger = loggerFactory.CreateLogger("WeatherForecast")
        logger.LogInformation("GET request")
        let rng = Random()
        [
            for index in 0..4 ->
                { Date = DateTime.Now.AddDays(index)
                  TemperatureC = rng.Next(-20, 55)
                  Summary = rng.GetItems(summaries, 1).[0] }
        ])) |> ignore

    app.Run()
    0

