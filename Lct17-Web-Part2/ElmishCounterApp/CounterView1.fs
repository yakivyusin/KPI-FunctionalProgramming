module CounterView1

open CounterLogic
open Fable.React
open Fable.React.Props

(*
    view з використанням Fable.React
*)
let view model dispatch =
    div []
        [
            button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
            div [] [ str (string model.Count) ]
            button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
        ]
