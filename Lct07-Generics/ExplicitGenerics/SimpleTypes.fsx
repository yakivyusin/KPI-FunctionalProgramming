(*
    Узагальнений запис.
*)
type KeyValue<'Key, 'Value> = { Key: 'Key; Value: 'Value }

(*
    Узагальнене об'єднання.
    Любителі монад, проходьте, не затримуйтеся, тут поки що немає на що дивитися.
*)
type LeftOrRight<'Left, 'Right> =
    | Left of 'Left
    | Right of 'Right

(*
    Компілятор все автоматично виводить.
*)
let intStringValue = { Key = 10; Value = "10" }
let guidIntValue = { Key = System.Guid.NewGuid(); Value = 100 }

// 'a -> 'b -> KeyValue<'a, 'b>
let toRecord key value = { Key = key; Value = value }

// KeyValue<'a, 'b> -> 'a -> 'b
let fromRecord { Key = key; Value = value } = (key, value)

// LeftOrRight<int, 'a>
let leftInt = Left 10

// LeftOrRight<'a, string>
let rightString = Right "Hello"

// LeftOrRight<'a, 'b> -> unit, тому що немає специфічного використання значень-випадків
let genericMatch =
    function
    | Left x -> printfn "Left: %A" x
    | Right x -> printfn "Right: %A" x

genericMatch leftInt
genericMatch rightString

// LeftOrRight<float, int> -> unit
let leftFloatRightIntMatch =
    function
    | Left x -> printfn "Left float: %f" x
    | Right x -> printfn "Right int: %i" x

// fail: leftFloatRightIntMatch leftInt
// fail: leftFloatRightIntMatch rightString

// int -> LeftOrRight<int, int>
let leftOrRightInt x = if x < 5 then Left x else Right x

leftOrRightInt 1
leftOrRightInt 10
