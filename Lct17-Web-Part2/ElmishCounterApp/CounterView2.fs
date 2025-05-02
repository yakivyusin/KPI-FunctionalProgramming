module CounterView2

open CounterLogic
open Feliz

(*
    view, але використовуючи DSL із Feliz замість Fable.React
*)
let view model dispatch =
    Html.div [
        Html.button [ prop.onClick (fun _ -> dispatch Increment); prop.text "+" ]
        Html.span [ prop.text (string model.Count) ]
        Html.button [ prop.onClick (fun _ -> dispatch Decrement); prop.text "-" ]
    ]
