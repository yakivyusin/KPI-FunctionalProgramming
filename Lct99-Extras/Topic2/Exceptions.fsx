(* Краще дивитися після: лекція 5 *)

(*
    Оскільки F# працює на платформі .NET, то сама логіка виключень повністю така ж, як і в інших мовах платформи.
    Але є певні особливості.
*)

(*
    Вираз try...with є аналогом твердження try {} catch {}.
    Оскільки він вираз, то всі підвирази ("гілки") мають повертати той самий тип.
*)

let divide1 x y =
    try
        x / y
    with
        | :? System.DivideByZeroException -> 0

divide1 4 2
divide1 4 0

(*
    Вираз try...finally є аналогом твердження try {} finally {}.
    Якщо нам необхідно мати аналог try {} catch {} finally {}, то тоді ми маємо вкладати два вирази один в один.
*)
let divide2 x y =
    try
        x / y
    finally
        printfn "Finally block"

divide2 4 0

(*
    Аналогом throw є функція raise.
*)
let divide3 x y =
  if (y = 0) then raise (System.ArgumentException("Divisor cannot be zero!"))
  else
     x / y

divide3 4 0

(*
    Крім .NET виключень, F# також має функціональність під назвою Exception types.
    Вона спрощує створення власних типів виключень з даними, а також дозволяє
    прив'язувати ці дані у зразках try...with.
*)
exception MyError of string

let divide4 x y =
    if (y = 0) then raise (MyError("Divisor cannot be zero!"))
    else
        x / y

try
    divide4 4 0
with
| MyError(str) ->
    printfn "Error: %s" str
    0

(*
    Крім функції raise, є ще функція failwith.
    Вона дозволяє простіше викинути System.Exception, передавши його текст.
*)
let divide5 x y =
    if (y = 0) then failwith "Divisor cannot be zero!"
    else
        x / y

(*
    Для System.Exception у нас є ім'я у F# - Failure.
*)
try
    divide5 4 0
with
| Failure(str) ->
    printfn "Error: %s" str
    0
