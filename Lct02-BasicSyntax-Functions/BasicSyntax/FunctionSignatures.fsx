let tupledForm (a: int, b: int) : int = a + b

// int -> int -> int
let curriedForm (a: int) (b: int) : int = a + b

(*
    Для виклику функції у tupled form необхідно взяти всі параметри в дужки і записати через кому.
    Для curried form - пишемо параметри без дужок та розділяємо пробілом.
*)

tupledForm (5, 10)
curriedForm 5 10

// int -> int
let inc (value: int) : int = value + 1

// int -> unit
let print (value: int) : unit = printfn "%d" value

// unit -> int
let random () : int = 42

// unit -> unit
let hello () : unit = printfn "Hello"
