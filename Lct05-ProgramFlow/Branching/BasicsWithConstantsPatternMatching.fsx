let number = 42
let result =
    match number with
    | 1 -> "one"
    | 2 -> "two"
    | _ -> "unknown"

printf "%s" result

(*
    Якщо наші зразки не покривають всі можливі випадки, ми отримаємо попередження від компілятора.
    Зразок _ підходить під будь-яке значення.
*)
let result2 =
    match number with
    | 1 -> "one"

(*
    Порядок має значення - буде використовуватися перший зразок, під яке підходить значення.
    Якщо ми поставимо _ наперед, жоден із інших зразків спрацьовувати не буде.
    На щастя, компілятор відслідковує зразки, які ніколи не спрацюють.
*)
let result3 =
    match number with
    | _ -> "unknown"
    | 1 -> "one"

(*
    | та match повинні бути вирівняні.
    Тому краще починати match з нового рядка, щоб код виглядав краще.
    Якщо у "гілці" великий вираз, його краще починати з нового рядка.
*)

//let result2 =
//    match number with
//| 1 -> "one"
//| _ -> "unknown"

//let result2 = match number with
//              | 1 -> "one"
//              | 2 -> "two"
//              | _ -> "unknown"

//let result2 =
//    match number with
//    | 1 ->
//        "one"
//    | 2 ->
//        "two"
//    | _ ->
//        "unknown"

(*
    match ... with є виразом, то чому б і ні?
*)

match number with
| 1 -> "one"
| 2 -> "two"
| _ -> "unknown"
|> printfn "%s"

match number with
| 1 -> "one"
| 2 -> "two"
| _ ->
    match number with
    | 3 -> "three"
    | 4 -> "four"
    | _ -> "unknown"
|> printfn "%s"

let numberToString num =
    match num with
    | 1 -> "one"
    | 2 -> "two"
    | _ -> "unknown"

number |> numberToString |> printfn "%s"

// Для функцій-зіставлень є ключове слово function, щоб трішки скоротити код
let numberToString2 =
    function
    | 1 -> "one"
    | 2 -> "two"
    | _ -> "unknown"

number |> (numberToString2 >> printfn "%s")

(*
    Наступні два зіставлення еквівалентні
*)
match number with
| 1 -> "one"
| 2 -> "two"
| 3
| 4 -> "three or four"
| _ -> "unknown"
|> printfn "%s"

match number with
| 1 -> "one"
| 2 -> "two"
| 3 | 4 -> "three or four"
| _ -> "unknown"
|> printfn "%s"
