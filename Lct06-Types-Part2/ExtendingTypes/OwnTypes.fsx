type Person = { First: string; Last: string }
type Person with
    static member Create first last = { First = first; Last = last }
    member this.FullName = $"{this.First} {this.Last}"

let john = Person.Create "John" "Doe"
printfn "%s" john.FullName

(*
    Ми можемо поєднувати оголошення типу з прикріпленням функцій.
    this не обов'язково має називатися this, можна використовувати будь-який плейсхолдер.
*)
type IntOrBool = I of int | B of bool with
    member self.ToStringValue () =
        match self with
        | I i -> $"Int {i}"
        | B b -> $"Bool {b}"

let i = I 45
let b = B true

i.ToStringValue () |> printfn "%s"
b.ToStringValue () |> printfn "%s"
