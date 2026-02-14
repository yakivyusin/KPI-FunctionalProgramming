(*
    Клас із приватними (звичайними та статичними) полями та методами,
    вручну реалізованими властивостями на основі цих полів.
*)
type Student(name: string, age: int, groupNo: string) =
    (*
        Для створення приватних членів використовуємо let прив'язку.
        age та groupNo відмічені як мутабельні для змін через сеттери властивостей.
    *)
    let _name = name
    let mutable _age = age
    let mutable _groupNo = groupNo

    let agePlusNum num = _age + num

    (*
        Для статичних приватних членів - static let
    *)
    static let _university = "KPI"

    (*
        read-only, write-only та read-write властивості відповідно.
    *)

    member this.Name = _name
    member this.GroupNo
        with set(value) = _groupNo <- value

    member this.Age
        with get () = _age
        and set (value) = _age <- value

    (*
        Використовуємо приватний метод.
    *)
    member this.AgePlusNum num = agePlusNum num

    member this.Print () = printfn "%s %i %s" _name _age _groupNo

let john = Student ("John Smith", 18, "KP-21")

john.Print ()

john.GroupNo <- "KP-31"
john.Age <- 20

john.Print ()

john.AgePlusNum 10 |> printfn "%i"
