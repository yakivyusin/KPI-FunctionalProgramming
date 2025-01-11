let map1 = Map.empty |> Map.add 1 "1"
let map2 = [(1, "1"); (2, "2")] |> Map.ofList

(*
    У F# додавання з тим же ключем оновлює значення
*)
map1 |> Map.add 1 "10"

map2 |> Map.find 2
