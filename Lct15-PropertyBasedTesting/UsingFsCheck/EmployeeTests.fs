module ``Employee Tests``

open FsCheck
open FsCheck.Xunit
open FsCheck.FSharp

type Employee = { Name: string; Age: int }
type Department = { Name: string; Team: Employee list }

let isLargeDepartment department = department.Team.Length > 10
let isLessThanTwenty person = person.Age < 20

(*
    Зазвичай FsCheck достатньо 20-30 тестів, щоб дійти до значень більше 20.
*)
[<Property>]
let ``is Employee young for any age`` age =
    isLessThanTwenty { Name = "Jane Smith"; Age = age }

[<Property>]
let ``is Employee young when age < 20`` age =
    age < 20 ==> isLessThanTwenty { Name = "Jane Smith"; Age = age }

(*
    У попередньому тесті вираз праворуч від ==> обчислюється для будь-яких age, незважаючи на значення умови зліва.
    Щоб запускати властивість тільки тоді, коли умова дійсно виконується, ми можемо використовувати вбудований lazy (System.Lazy).
*)
[<Property>]
let ``is Department large when team > 10`` team =
    (team |> List.length) > 10 ==> lazy isLargeDepartment { Name = "Super Department"; Team = team }

(*
    Всі вбудовані типи знаходяться у просторі імен FsCheck.
    Оскільки всі вони є об'єднаннями з одним випадком, ми можемо їх деконструювати у параметрах.
*)
[<Property>]
let ``is Employee young with PositiveInt`` (NonEmptyString name) (PositiveInt age) =
    age < 20 ==> isLessThanTwenty { Name = name; Age = age }
