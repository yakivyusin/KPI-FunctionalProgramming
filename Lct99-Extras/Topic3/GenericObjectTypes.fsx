(* Краще дивитися після: лекція 11 *)

(*
    Ми можемо створювати узагальнені класи та інтерфейси, як і будь-які інші типи.
*)

type IGenericInterface<'T> =
    abstract member Get: unit -> 'T
    abstract member GetToString: unit -> string

type MyClass<'T>(t: 'T) =
    interface IGenericInterface<'T> with
        member this.Get () = t
        member this.GetToString () = t.ToString().ToUpper()

let stringValue: IGenericInterface<string> = MyClass "Hello, World"
stringValue.GetToString () |> printfn "%s"

let intValue: IGenericInterface<int> = MyClass 1
intValue.GetToString () |> printfn "%s"
