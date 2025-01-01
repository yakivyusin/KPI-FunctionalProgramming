let getLimit customer =
    match customer with
    | ("medium", 1) -> 500
    | ("good", 0) | ("good", 1) -> 750
    | ("good", 2) -> 1000
    | ("good", _) -> 2000
    | _ -> 250

match System.Int32.TryParse("10") with
| (true, i) -> printfn "%d" i
| (false, _) -> printfn "error"

(*
    Тут нам не потрібен _, адже всі зразки кортежів і так покривають всі можливі випадки.
    Загальною рекомендацією є обходитися без _ там, де це можливо
*)
match (0, 0) with
| (0, 0) -> printfn "zero point"
| (1, _) -> printfn "first part is 1"
| (_, 1) -> printfn "second part is 1"
| (x, y) -> printfn "%i %i" x y

(*
    Якщо нам треба одночасно зіставити декілька значень - просто поєднуємо їх у кортеж.
    Чи використовувати дужки у зразках - просто питання code style, адже головним для кортежу є кома.
*)
let getLimit2 rating years =
    match rating, years with
    | "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _ -> 250

(*
    Зіставити кортеж із кортежів - чому б і ні?
*)
match ("medium", 1), ("good", 2) with
| ("medium", _), _ -> printfn "First rating is medium"
| (_, 1), (_, 1) -> printfn "Both are first year"
| ((_, 2), _) & (_, (_, 2)) -> printfn "Both are second year"
| _, _ -> printfn "Something else"
