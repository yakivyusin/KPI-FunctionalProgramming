(*
    Земулюємо функцію пошуку у БД.
*)
type Student = { Id: int; Name: string; Age: int }

let tryFindStudentById id =
    match id with
    | 0 -> Error "Not found"
    | 1 -> Ok (Some { Id = 1; Name = "John Smith"; Age = 20 })
    | _ -> Ok None

(*
    Якась умовна трансформація студента, яка є "чистою"
*)
let transformStudent student = { student with Age = student.Age + 10 }

(*
    :-(
*)
//tryFindStudentById 1
//|> Result.map transformStudent
//|> function
//   | Ok x -> printfn "%A" x
//   | Error x -> printfn "%A" x

(*
    :-)
*)
tryFindStudentById 1
|> Result.map (Option.map transformStudent)
|> function
   | Ok x -> printfn "%A" x
   | Error x -> printfn "%A" x
