(*
    Визначаємо інтерфейс.
*)
type INamePlusAge =
    abstract member NamePlusAge: unit -> string

(*
    Реалізуємо інтерфейс класом.
    Синтаксис такий же, як і для інших типів.
*)
type Student(name: string, age: int) =
    interface INamePlusAge with
        member this.NamePlusAge () = sprintf "%s %i" name age

("Jane Doe", 18) |> Student |> (fun x -> x :> INamePlusAge) |> (fun x -> printfn "%s" <| x.NamePlusAge ())
