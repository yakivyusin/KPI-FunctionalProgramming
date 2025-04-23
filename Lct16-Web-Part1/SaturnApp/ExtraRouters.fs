module SaturnApp.ExtraRouters

open Giraffe
open Saturn
open SaturnApp
open System

(*
    Наш роутер для прогнозу погоди.
*)
let weatherForecastsRouter = router {
    (*
        Визначаємо шлях GET /, якому відповідає вбудований обробник json.
    *)
    get "" (json <| WeatherForecast.getForWeek DateTime.Now)

    (*
        Оператор >=> використовується для комбінування декількох обробників у один.
        Визначаємо шлях POST /, якому відповідають два вбудовані обробники.
    *)
    post "" (setStatusCode 201 >=> setHttpHeader "Location" "/")

    (*
        Якщо ми хочемо визначити параметр у нашому шляху, використовуємо методи із суфіксом f.
        Тут %s - параметр-рядок.
    *)
    getf "/%s" (fun date -> json <| (WeatherForecast.getForDay <| DateTime.Parse date))
}

(*
    Створюємо кореневий роутер, у який буде вкладений наш прогноз погоди.
*)
let webApp1 = router {
    (*
        Реєструємо для певного шляху вкладений роутер.
        Цей шлях буде додаватися до всіх вкладених шляхів, тому ми матимемо шляхи:
        * GET /api/weatherforecasts
        * POST /api/weatherforecasts
        * GET /api/weatherforecasts/%s, наприклад /api/weatherforecasts/2025-01-01
    *)
    forward "/api/weatherforecasts" weatherForecastsRouter
}

(*
    Контролер - це REST роутер, який знає, якій операції який шлях повинен відповідати.
*)
let weatherForecastsController = controller {
    (*
        index - отримати всю колекцію ресурсів.
    *)
    index (fun ctx -> WeatherForecast.getForWeek DateTime.Now |> Controller.json ctx)

    (*
        show - отримати ресурс за ідентифікатором.
    *)
    show (fun ctx (date: string) -> WeatherForecast.getForDay (DateTime.Parse date) |> Controller.json ctx)

    (*
        create - створення ресурсу у колекції.
    *)
    create (fun ctx -> task {
        let! body = ctx.BindModelAsync<WeatherForecast.T>()

        return Response.created ctx <| WeatherForecast.add body
    })

    (*
        Див. також: delete, delete_all, patch, update.
    *)
}

(*
    Контролер всюди може заміняти роутер, наприклад, при вкладеності у корінь.
*)
let webApp2 = router {
    forward "/api/weatherforecasts" weatherForecastsController
}
