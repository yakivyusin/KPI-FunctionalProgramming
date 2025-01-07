open System

(*
    Null Constraint
*)

let checkOnNull<'T when 'T : null> (x: 'T) =
    match x with
    | null -> printfn "Is null"
    | _ -> printfn "Is not null"

let checkOnNullAuto =
    function
    | null -> printfn "Is null"
    | _ -> printfn "Is not null"

checkOnNull (Object())
// fail: checkOnNullAuto (1, 2)

(*
    Value Type Constraint
*)

let onlyValue<'T when 'T : struct> (x: 'T) = x

onlyValue 10 |> printfn "%A"
// fail: onlyValue (1, 2) |> printfn "%A"
// fail: onlyValue {| A = "A" |} |> printfn "%A"
// fail: onlyValue (Object()) |> printfn "%A"

(*
    Reference Type Constraint
*)

let onlyRef<'T when 'T : not struct> (x: 'T) = x

onlyRef (1, 2) |> printfn "%A"
onlyRef {| A = "A" |} |> printfn "%A"
onlyRef (Object()) |> printfn "%A"
// fail: onlyRef 10 |> printfn "%A"

(*
    Enumeration Type Constraint
*)

let onlyEnum<'T when 'T : enum<int>> (x: 'T) = Enum.GetName(x.GetType(), x)

onlyEnum DayOfWeek.Monday |> printfn "%A"
// fail: onlyEnum 10 |> printfn "%A"

(*
    Constructor Constraint
*)

let defaultValue<'T when 'T : (new: unit -> 'T)> = new 'T()

defaultValue<Object> |> printfn "%A"
// fail: defaultValue<int * int>
// fail: defaultValue<{| First: string |}>

(*
    Type Constructor
*)

let streamLength<'T when 'T :> IO.Stream> (x: 'T) = x.Length

(*
    Equality Constraint
*)

let areEqual<'T when 'T : equality> (x: 'T) (y: 'T) = (x = y)

let areEqualAuto x y = (x = y)

areEqual (1, 2) (1, 2) |> printfn "%A"
areEqualAuto {| First = "Jane" |} {| First = "John "|} |> printfn "%A"
areEqualAuto (Object()) (Object()) |> printfn "%A"

(*
    Comparison Constraint
*)

let lessThan<'T when 'T : comparison> (x: 'T) (y: 'T) = (x < y)

let lessThanAuto x y = (x < y)

lessThan 1 2 |> printfn "%A"
lessThanAuto (1, 2) (1, 3) |> printfn "%A"
lessThanAuto {| Last = "Smith" |} {| Last = "Doe" |} |> printfn "%A"
// fail: lessThanAuto (Object()) (Object())

(*
    Об'єднувати обмеження можна через and
*)

let isEqualToNull<'T when 'T : null and 'T : equality> (x: 'T) = (x = null)

let isEqualToNullAuto x = (x = null)

isEqualToNull (Object())
// fail: isEqualToNullAuto (1, 2)

type KeyValue<'Key, 'Value when 'Key : not null and 'Key : equality and 'Value : not struct> =
    { Key: 'Key
      Value: 'Value }
