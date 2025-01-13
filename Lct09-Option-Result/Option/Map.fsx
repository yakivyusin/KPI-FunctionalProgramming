(*
    Наша чиста функція, яка просто бере "чисте" значення та перетворює його у інше.
    Вона нічого не знає про колекції, Option'и чи інші типи-контейнери.
*)
let stringify i = i.ToString()

(*
    Якщо наш тип-контейнер має функцію map чи аналогічну, то ми можемо
    використовувати нашу чисту функцію на цьому типі для перетворення "чистих" значень всередині.
*)
[1; 2; 3] |> List.map stringify |> printfn "%A"
[] |> List.map stringify |> printfn "%A"

[| 1; 2; 3 |] |> Array.map stringify |> printfn "%A"
[| |] |> Array.map stringify |> printfn "%A"

Array2D.init 5 5 (fun r c -> (r, c)) |> Array2D.map stringify |> printfn "%A"

(*
    Для option map це наступне зіставлення:
    match option with
	| None -> None
	| Some x -> Some(mapping x)
*)
Some 1 |> Option.map stringify |> printfn "%A"
None |> Option.map stringify |> printfn "%A"

(*
    Виклики map легко об'єднуються у конвеєр / композицію.
*)
let pipeOption x = x |> Option.map ((+) 1) |> Option.map ((*) 2) |> Option.map ((+) 10) |> Option.map ((*) 3)

Some 1 |> pipeOption |> printfn "%A"
None |> pipeOption |> printfn "%A"

let compositeOption = Option.map ((+) 1) >> Option.map((*) 2) >> Option.map ((+) 10) >> Option.map((*) 3)

Some 1 |> compositeOption |> printfn "%A"
None |> compositeOption |> printfn "%A"
