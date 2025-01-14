(*
    Будемо працювати (валідувати / перетворювати) з таким типом:
*)
type Student = { Name: string; Age: int; GroupCode: string }

(*
    Наше "enum-style" об'єднання для переліку помилок.
*)
type StudentValidationError = InvalidName | InvalidAge | InvalidGroupCode

let printValidationResult =
    function
    | Ok _ -> printfn "Valid student record."
    | Error err -> printfn "Invalid student record. %A" err

let printStudent =
    function
    | Ok s -> printfn "Student %s %i %s" s.Name s.Age s.GroupCode
    | Error _ -> printfn "Invalid student"

let validateName student =
    if System.String.IsNullOrWhiteSpace(student.Name) then
        Error InvalidName
    else
        Ok student

let validateAge student =
    if student.Age < 10 || student.Age > 20 then
        Error InvalidAge
    else
        Ok student

let validateGroupCode student =
    if System.String.IsNullOrWhiteSpace(student.GroupCode) then
        Error InvalidGroupCode
    else
        Ok student

(*
    Створимо окремо функцію валідації, щоб її можна було викликати окремо.
*)
let validateStudent student =
    Ok student
    |> Result.bind validateName
    |> Result.bind validateAge
    |> Result.bind validateGroupCode

{ Name = "John Smith"; Age = 10; GroupCode = "KP-21" } |> validateStudent |> printValidationResult
{ Name = ""; Age = 10; GroupCode = "KP-21" } |> validateStudent |> printValidationResult
{ Name = "Jane Doe"; Age = 5; GroupCode = "KP-21" } |> validateStudent |> printValidationResult
{ Name = "Jane Doe"; Age = 15; GroupCode = "" } |> validateStudent |> printValidationResult

let nameToUpper student = { student with Name = student.Name.ToUpper() }
let agePlus5 student = { student with Age = student.Age + 5 }
let groupCodeToUpper student = { student with GroupCode = student.GroupCode.ToUpper() }

(*
    Створимо окремо функцію трансформації
*)
let transformStudent student =
    Ok student
    |> Result.map nameToUpper
    |> Result.map agePlus5
    |> Result.map groupCodeToUpper

{ Name = "John Smith"; Age = 15; GroupCode = "kp-21" } |> transformStudent |> printStudent

(*
    Єдиний конвеєр.
*)
let processStudent student =
    Ok student
    |> Result.bind validateName
    |> Result.bind validateAge
    |> Result.bind validateGroupCode
    |> Result.map nameToUpper
    |> Result.map agePlus5
    |> Result.map groupCodeToUpper

{ Name = "John Smith"; Age = 10; GroupCode = "KP-21" } |> processStudent |> printStudent
{ Name = ""; Age = 10; GroupCode = "KP-21" } |> processStudent |> printStudent
{ Name = "Jane Doe"; Age = 5; GroupCode = "KP-21" } |> processStudent |> printStudent
{ Name = "Jane Doe"; Age = 15; GroupCode = "" } |> processStudent |> printStudent
