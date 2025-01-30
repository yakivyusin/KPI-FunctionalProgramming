(*
    Є ще інші додаткові bang'и для спрощення певних шаблонів, таких як return!.
*)

(*
    match! замість послідовних let! та match.
*)
open System.Threading.Tasks

let taskOption () = Task.FromResult <| Some 1

let validate () = task {
    match! taskOption () with
    | Some x -> printfn "Some with %i" x
    | None -> printfn "None"
}

validate ()

(*
    while! замість мутабельного значення з let! та while.
*)
open System

let asyncRandom =
    let r = Random ()
    fun () -> Task.FromResult <| (r.Next 10 <> 0)

let printWhile () = task {
    while! asyncRandom () do
        printfn "Loop..."
}

printWhile ()
