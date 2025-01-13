let iHaveIntData = Some 1
let iHaveStringData = Some "1"
let noData = None

(*
    Використовуємо Option у типі-записі.
    Вік може бути як вказаний, так і не вказаний.
    У анотації типу ми також можемо написати int option - це буде те саме.
*)
type Student = { Name: string; Age: Option<int> }

let s1 = { Name = "John Doe"; Age = Some 18 }
let s2 = { Name = "Jane Smith"; Age = None }

let printStudentAge { Age = age } =
    match age with
    | Some x -> printfn "Student is %i old" x
    | None -> printfn "Student age is unknown"

printStudentAge s1
printStudentAge s2

(*
    У модуль Option упаковані найчастіші операції, які ми можемо робити над Option через зіставлення зі зразком.
        кхм, шаблони, кхм.
    Всі функції модуля відмічені як inline, тому насправді компілятор підставляє відповідне зіставлення відразу у код.
*)

(*
    match option with
    | None -> defaultValue
    | Some v -> v
*)
Some 1 |> Option.defaultValue 100 |> printfn "%i"
None |> Option.defaultValue 100 |> printfn "%i"

(*
    match option with
    | None -> ifNone
    | Some _ -> option
*)
Some 1 |> Option.orElse (Some 100) |> printfn "%A"
None |> Option.orElse (Some 100) |> printfn "%A"

(*
    match option with
    | None -> false
    | Some v -> v = value
*)
Some 1 |> Option.contains 1 |> printfn "%b"
Some 1 |> Option.contains 2 |> printfn "%b"
None |> Option.contains 1 |> printfn "%b"

(*
    match option with
    | None -> ()
    | Some x -> action x
*)
Some 1 |> Option.iter (printfn "%i")
None |> Option.iter (printfn "%i")

(*
    match option with
    | None -> None
    | Some x -> if predicate x then Some x else None
*)
Some 1 |> Option.filter (fun x -> x > 0) |> printfn "%A"
Some 1 |> Option.filter (fun x -> x > 1) |> printfn "%A"
None |> Option.filter (fun x -> x > 0) |> printfn "%A"

(*
    match option with
    | None -> false
    | Some x -> predicate x
*)
Some 1 |> Option.exists (fun x -> x > 0) |> printfn "%b"
Some 1 |> Option.exists (fun x -> x > 1) |> printfn "%b"
None |> Option.exists (fun x -> x > 0) |> printfn "%b"

(*
    match option with
    | None -> true
    | Some x -> predicate x
*)
Some 1 |> Option.forall (fun x -> x > 0) |> printfn "%b"
Some 1 |> Option.forall (fun x -> x > 1) |> printfn "%b"
None |> Option.forall (fun x -> x > 0) |> printfn "%b"
