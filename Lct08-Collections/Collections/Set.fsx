let set1 = Set.empty |> Set.add 10 |> Set.add 5 |> Set.add 10

(*
    Функція Set.add також прив'язана до типу, тому можна робити і так:
*)
Set.empty.Add(10).Add(5).Add(10)

let set2 = set [| 5; 11; 20 |]
let set3 = Set.ofList [10; 20; 30]

(*
    Модуль Set має набір функцій для операцій над множинами.
*)
Set.minElement set1
Set.maxElement set1
Set.isSubset set1 set2
Set.union set1 set2
Set.intersect set1 set2
Set.difference set3 set1

(*
    Також маємо перевизначені оператори + та - для об'єднання та різниці множин.
*)
set1 + set2
set3 - set1
