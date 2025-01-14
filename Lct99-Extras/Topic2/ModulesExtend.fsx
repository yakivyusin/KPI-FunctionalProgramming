(* Краще дивитися після: лекція 9 *)

(*
    Ми не можемо оголосити один модуль у двох файлах у одному проєкті.
    Але якщо модуль "не наш" (визначений не у нашому проєкті), то ми можемо його розширити.
    В результаті ми зможемо викликати ці функції як оголошенні у цьому ж модулі.

    Як приклад, додамо до модуля Result функції для роботи із вкладеним Option.
*)

module Result =
    let optMap mapper result = Result.map (Option.map mapper) result
    let optBind binder result = Result.map (Option.bind binder) result

let add1 num = num + 1
let add1ifEven num = if num % 2 = 0 then Some(num + 1) else None

let res = Ok (Some 1)

Result.optMap add1 res |> printfn "%A"

Result.optBind add1ifEven res |> printfn "%A"
