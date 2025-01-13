(*
    map нам чудово підходить, якщо ми хочемо використовувати "чисту" функцію
    для перетворення значень у нашому типі-контейнері.
    Але не підходить, якщо наша функція повертає значення упаковане у тип-контейнер.
*)

let add2IfEven x = if x % 2 = 0 then Some(x + 2) else None

Some 1 |> Option.map add2IfEven |> printfn "%A"
Some 2 |> Option.map add2IfEven |> printfn "%A"

(*
    bind допомагає "розпакувати" значення.
    match option with
	| None -> None
	| Some x -> binder x
*)

Some 1 |> Option.bind add2IfEven |> printfn "%A"
Some 2 |> Option.bind add2IfEven |> printfn "%A"

(*
    Як і map та інші функції модуля, bind легко об'єднується у конвеєр / композицію.
*)
let validationPipeline num =
    Some num
    |> Option.bind (fun x -> if x % 2 = 0 then Some x else None) // div by 2?
    |> Option.bind (fun x -> if x % 3 = 0 then Some x else None) // div by 3?
    |> Option.bind (fun x -> if x % 4 = 0 then Some x else None) // div by 4?
    |> Option.bind (fun x -> if x % 5 = 0 then Some x else None) // div by 5?

validationPipeline 60 |> printfn "%A"
validationPipeline 50 |> printfn "%A"
