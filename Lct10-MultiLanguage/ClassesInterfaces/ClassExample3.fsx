(*
    Клас з автоматично реалізованими властивостями.
*)
type Student(name: string, age: int) =
    (*
        read-only
    *)
    member val Name = name

    (*
        read-write
    *)
    member val Age = age with get, set

let jane = Student ("Jane Smith", 18)
jane.Name |> printfn "%s"
jane.Age |> printfn "%i"
jane.Age <- 20
jane.Age |> printfn "%i"
