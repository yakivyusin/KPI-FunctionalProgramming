(*
    Деякі функції колекцій є небезпечними у тому сенсі, що якщо вони не можуть виконати операцію, то виникне виключення.
    Це:
        average, max, maxBy, min, minBy - для порожньої колекції.
        find, findBack, findIndex, findIndexBack - для порожньої колекції або якщо у колекції немає значення, що задовольняє предикату.
        head, last, tail - для порожньої колекції.
*)
List.empty<float> |> List.average |> printfn "%f"
List.empty<int> |> List.max |> printfn "%i"
List.empty<int> |> List.min |> printfn "%i"
[1] |> List.find (fun x -> x > 2) |> printfn "%i"
[1] |> List.findBack (fun x -> x > 2) |> printfn "%i"
[1] |> List.findIndex (fun x -> x > 2) |> printfn "%i"
[1] |> List.findIndexBack (fun x -> x > 2) |> printfn "%i"
List.empty<int> |> List.head |> printfn "%i"
List.empty<int> |> List.last<int> |> printfn "%i"
List.empty<int> |> List.tail<int> |> printfn "%A"

(*
    Деякі з "небезпечних" функцій мають безпечні аналоги, що починаються з приставки try.
    Всі безпечні функції повертають 'T option:
        Some x, якщо операція виконана
        None, якщо операцію неможливо виконати
*)
[1] |> List.tryFind (fun x -> x > 2) |> printfn "%A"
[1] |> List.tryFindBack (fun x -> x > 2) |> printfn "%A"
[1] |> List.tryFindIndex (fun x -> x > 2) |> printfn "%A"
[1] |> List.tryFindIndexBack (fun x -> x > 2) |> printfn "%A"
List.empty<int> |> List.tryHead |> printfn "%A"
List.empty<int> |> List.tryLast |> printfn "%A"

(*
    Функцію choose можна використовувати для того, щоб перетворити та відразу відфільтрувати "недопустимі" значення.
*)
let tryParseInt (x: string) =
    match System.Int32.TryParse(x) with
    | (true, i) -> Some i
    | (false, _) -> None

["1"; "10"; "not int"; "20"] |> List.choose tryParseInt |> printfn "%A"
["1"; "10"; "not int"; "20"] |> List.pick tryParseInt |> printfn "%i"

(*
    pick, як і find, також є небезпечним і має аналог tryPick
*)
["not int"; "not int"] |> List.pick tryParseInt |> printfn "%i"
["not int"; "not int"] |> List.tryPick tryParseInt |> printfn "%A"
