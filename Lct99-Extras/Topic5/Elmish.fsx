(* Краще дивитися після: лекція 17 *)

(*
    Зазвичай наші застосунки складаються з ієрархії компонентів.
    Продемонструємо, як це реалізується у архітектурі Model-View-Update.
*)

#r "nuget: Elmish"

(*
    Модуль з нашим child компонентом.
*)
module Counter =
    type Model = { Count: int }

    type Msg = | Increment | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        printfn "Counter: %A" model

(*
    Модуль з нашим parent компонентом.
    Він містить два звичайних лічильника, і користувач може змінювати стан того чи іншого.
*)
module DoubleCounter =
    type Model =
        { Top: Counter.Model
          Bottom: Counter.Model }

    type Msg =
        | TopCounter of Counter.Msg
        | BottomCounter of Counter.Msg

    let init () =
        { Top = Counter.init ()
          Bottom = Counter.init () }

    let update msg model =
        match msg with
        | TopCounter childMsg -> { model with Top = Counter.update childMsg model.Top }
        | BottomCounter childMsg -> { model with Bottom = Counter.update childMsg model.Bottom }

    let view model dispatch =
        printf "Top: "
        Counter.view model.Top
        printf "Bottom: "
        Counter.view model.Bottom
        printfn "Enter new command (T+ / T- / B+ / B-)"

        match System.Console.ReadLine() with
        | "T+" -> dispatch (Msg.TopCounter Counter.Msg.Increment)
        | "T-" -> dispatch (Msg.TopCounter Counter.Msg.Decrement)
        | "B+" -> dispatch (Msg.BottomCounter Counter.Msg.Increment)
        | "B-" -> dispatch (Msg.BottomCounter Counter.Msg.Decrement)
        | _ -> printfn "Unknown command! Exit"

open Elmish
open DoubleCounter

Program.mkSimple init update view
|> Program.run
