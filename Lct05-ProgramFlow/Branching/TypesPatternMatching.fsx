(*
    Коли працюємо з ООП, нам можуть бути необхідними зіставлення по типам чи з null.
*)

let x = new System.Object()
match x with
| :? System.Int32 -> printfn "matched an int"
| :? System.DateTime -> printfn "matched a datetime"
| _ -> printfn "another type"

match x with
| null -> printfn "null"
| _ -> printfn "not null"
