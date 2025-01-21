open CSharpClassLibrary

let john = Person "John Smith"
john.PrintName ()

(*
    Конструктори це просто функції, тому ми їх можемо передати у HOF.
*)
["John Smith"; "Jane Doe"; "Sara Doe"] |> List.map Person |> List.iter (fun x -> x.PrintName ())

Person.GetDefault () |> _.Name |> Option.ofObj |> printfn "%A"

type OwnPerson = { Name: string } with
    interface IPerson with
        member this.Name = this.Name
        member this.MakeFriend other = printfn "F# best friends with %s" other.Name

john.MakeFriend { Name = "Max Mueller" }

(*
    F# завжди реалізовує інтерфейси явно, тому якщо ми хочемо викликати його члени, потрібен каст.
*)
({ Name = "Jane Smith" } :> IPerson) |> (fun x -> x.MakeFriend john)

(*
    object expression.
*)
let object =
    { new IPerson with
        member this.Name = "Anonymous"
        member this.MakeFriend other = printfn "F# best friends with %s" other.Name }

john.MakeFriend object
object.MakeFriend john
