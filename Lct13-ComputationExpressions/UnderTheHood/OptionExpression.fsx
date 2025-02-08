type OptionBuilder() =
    member _.Bind (o, f) = Option.bind f o
    member _.Return x = Some x
    member _.ReturnFrom o = o

let option = OptionBuilder ()

type Student = { Name: string; Age: int; GroupCode: string }

let validateName student =
    if System.String.IsNullOrWhiteSpace(student.Name) then
        None
    else
        Some student

let validateAge student =
    if student.Age < 10 || student.Age > 20 then
        None
    else
        Some student

let validateGroupCode student =
    if System.String.IsNullOrWhiteSpace(student.GroupCode) then
        None
    else
        Some student

let nameToUpper student = { student with Name = student.Name.ToUpper() }
let agePlus5 student = { student with Age = student.Age + 5 }
let groupCodeToUpper student = { student with GroupCode = student.GroupCode.ToUpper() }

let processStudent student = option {
    (*
        Використовуємо shadowing, щоб не вигадувати нові назви типу validName, validAge і так далі.
    *)
    let! student = validateName student
    let! student = validateAge student
    let! student = validateGroupCode student
    return student |> nameToUpper |> agePlus5 |> groupCodeToUpper
}

let printStudent =
    function
    | Some s -> printfn "%A" s
    | None -> printfn "Invalid student"

{ Name = "John Smith"; Age = 10; GroupCode = "kp-21" } |> processStudent |> printStudent
{ Name = ""; Age = 10; GroupCode = "KP-21" } |> processStudent |> printStudent
{ Name = "Jane Doe"; Age = 5; GroupCode = "KP-21" } |> processStudent |> printStudent
{ Name = "Jane Doe"; Age = 15; GroupCode = "" } |> processStudent |> printStudent

(*
    Спрощений результат роботи компілятора.
*)
let processStudent2 student =
    option.Bind(student |> validateName, fun student ->
        option.Bind(student |> validateAge, fun student ->
            option.Bind(student |> validateGroupCode, fun student ->
                option.Return(student |> nameToUpper |> agePlus5 |> groupCodeToUpper))))

{ Name = "John Smith"; Age = 10; GroupCode = "kp-21" } |> processStudent2 |> printStudent
{ Name = ""; Age = 10; GroupCode = "KP-21" } |> processStudent2 |> printStudent
{ Name = "Jane Doe"; Age = 5; GroupCode = "KP-21" } |> processStudent2 |> printStudent
{ Name = "Jane Doe"; Age = 15; GroupCode = "" } |> processStudent2 |> printStudent
