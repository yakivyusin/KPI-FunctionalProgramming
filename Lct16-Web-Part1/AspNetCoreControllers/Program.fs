open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddControllers() |> ignore
    let app = builder.Build()

    app.MapControllers() |> ignore

    app.Run()
    0
