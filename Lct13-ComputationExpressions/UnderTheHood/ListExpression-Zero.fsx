type ListBuilder() =
    member _.Zero () = List.empty

let list = ListBuilder ()

(*
    Оскільки список буде порожнім, то потрібно додати анотацію типу, щоб компілятор знав тип елементів списку.
*)
let intList: int list = list {}
let stringList: string list = list {}

printfn "%A" intList
printfn "%A" stringList
