(* Краще дивитися після: лекція 11 *)

(*
    В F# ми також можемо використовувати "сучасні" .NET кортежі (System.ValueTuple).
    Для цього необхідно використовувати ключове слово struct при роботі із кортежем.
*)

(*
    Створення.
*)
let structTuple = struct (1, 2)

(*
    Деконструювання.
*)
let struct (firstValue, secondValue) = structTuple

(*
    Зіставлення зі зразком.
*)
match structTuple with
| struct (_, 3) -> printfn "Three last"
| struct (1, _) -> printfn "One first"
| struct (_, _) -> printfn "Any"

(*
    Параметр функції.
*)
let fstStruct struct (x, _) = x

// fail: structTuple |> fst |> printfn "%i"
structTuple |> fstStruct |> printfn "%i"

(*
    Псевдонім. Дужки обов'язкові.
*)
type StructTupleAlias = (struct (string * string))
