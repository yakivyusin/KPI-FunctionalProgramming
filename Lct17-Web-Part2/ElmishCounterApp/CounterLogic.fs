module CounterLogic

(*
    Наша чиста логіка, яка нічого не знає про відображення - модель, повідомлення, init та update.
*)

type Model = { Count: int }

type Msg = | Increment | Decrement

let init () = { Count = 0 }

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + 1 }
    | Decrement -> { model with Count = model.Count - 1 }
