(*
    Для останнього файлу компілятор автоматично оголошує модуль.
    Ім'я модуля співпадає з іменем файлу, але починається з великої літери.
    Тому повне ім'я функції - Program.main
*)

open Domain

[<EntryPoint>]
let main args =
    Domain.favoriteCustomer |> Domain.customerFullName |> printfn "%s"
    { City = "Kyiv"; Zip = "00000" } |> Domain.Utilities.stringifyAddress |> printfn "%s"
    Operations.createUnknownCity ("John", "Smith") |> Domain.Utilities.stringifyCustomer |> printfn "%s"
    0
