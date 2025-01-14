let success = Ok "Some data"
let error = Error "Operation failed"

printfn "%A" success
printfn "%A" error

(*
    Exception, якщо не було raise (throw), просто об'єкт, так що чому ні?
*)
let func id : Result<int, System.Exception> =
    match id with
    | 0 -> Error (System.InvalidOperationException ())
    | x when x < 0 -> Error (System.ArgumentOutOfRangeException ())
    | _ -> Ok id

func 0 |> printfn "%A"
func -1 |> printfn "%A"
func 1 |> printfn "%A"

(*
    Якщо потрібно, можемо працювати і зіставляти напряму, але навіщо, якщо є готовий модуль?
*)
match success with
| Ok x -> printfn "%s" x
| Error x -> printfn "%A" x

(*
    match result with
    | Error _ -> value
    | Ok v -> v
*)
success |> Result.defaultValue "Default data" |> printfn "%A"
error |> Result.defaultValue "Default data" |> printfn "%A"

(*
    match result with
    | Error _ -> false
    | Ok x -> predicate x
*)
success |> Result.exists (fun x -> x.Length > 5) |> printfn "%A"
success |> Result.exists (fun x -> x.Length > 20) |> printfn "%A"
error |> Result.exists (fun x -> x > 10) |> printfn "%A"

(*
    match result with
    | Error _ -> true
    | Ok x -> predicate x
*)
success |> Result.forall (fun x -> x.Length > 5) |> printfn "%A"
success |> Result.forall (fun x -> x.Length > 20) |> printfn "%A"
error |> Result.forall (fun x -> x > 10) |> printfn "%A"

(*
    match result with
    | Error _ -> false
    | Ok v -> v = value
*)
success |> Result.contains "Some data" |> printfn "%b"
success |> Result.contains "Some another data" |> printfn "%b"
error |> Result.contains "Some data" |> printfn "%b"

(*
    match result with
    | Error _ -> ()
    | Ok x -> action x
*)
success |> Result.iter (printfn "%A")
error |> Result.iter (printfn "%A")

(*
    match result with
    | Error _ -> None
    | Ok x -> Some x
*)
success |> Result.toOption |> printfn "%A"
error |> Result.toOption |> printfn "%A"
