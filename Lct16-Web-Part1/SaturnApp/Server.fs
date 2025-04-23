module SaturnApp.Server

open Giraffe
open Saturn
open SaturnApp.ExtraRouters
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection

(*
    Глобальний роутер із шаблону.
    Визначає один шлях GET /api/hello, якому відповідає вбудований обробник text.
*)
let webApp = router {
    get "/api/hello" (text "Hello from SAFE!")
}

let app = application {
    (*
        Встановлюємо роутер верхнього рівня для всього застосунку.
    *)
    use_router webApp

    (*
        Вмикаємо in-memory кешування даних.
    *)
    memory_cache

    (*
        Вмикаємо стиснення gzip для відповідей. 
    *)
    use_gzip

    (*
        Налаштовуємо логування.
    *)
    logging (fun logging -> logging.SetMinimumLevel LogLevel.Debug |> ignore)

    (*
        Можемо зареєструвати якісь сервіси у IoC-контейнері...
    *)
    service_config (fun services -> services)
}

run app
