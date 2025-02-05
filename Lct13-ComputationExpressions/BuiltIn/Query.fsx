open System.Linq

type Student =
    { FirstName: string
      LastName: string
      IsActive: bool
      Age: int
      Marks: int seq }

let data =
    [ { FirstName = "John"; LastName = "Smith"; IsActive = true; Age = 18; Marks = [99; 100; 100] };
    { FirstName = "Jane"; LastName = "Doe"; IsActive = true; Age = 20; Marks = [100; 100; 100] };
    { FirstName = "Max"; LastName = "Mueller"; IsActive = false; Age = 16; Marks = [60; 65; 64] };
    { FirstName = "John"; LastName = "Doe"; IsActive = true; Age = 20; Marks = [95; 94; 93] } ]

(*
    Ми можемо використовувати yield та yield!, але це не дасть доступу до власних операторів виразу.
*)
query {
    for student in data do
    yield student.LastName
} |> Seq.iter (printfn "%s")

query {
    for student in data do
    yield! student.Marks
} |> Seq.iter (printfn "%i")

// fail:
//query {
//    for student in data do
//    yield student.Age
//    contains 20
//} |> printfn "%b"

(* contains *)
query {
    for student in data do
    select student.Age
    contains 20
} |> printfn "%b"

(* exists *)
query {
    for student in data do
    exists (student.FirstName = "Jane")
} |> printfn "%b"

(* all *)
query {
    for student in data do
    all student.IsActive
} |> printfn "%b"

(* count *)
query {
    for student in data do
    count
} |> printfn "%i"

(* head *)
query {
    for student in data do
    head
} |> printfn "%A"

(* nth *)
query {
    for student in data do
    nth 2
} |> printfn "%A"

(* last *)
query {
    for student in data do
    last
} |> printfn "%A"

(* distinct *)
query {
    for student in data do
    select student.LastName
    distinct
} |> Seq.iter (printfn "%A")

(* sortBy / thenBy *)
query {
    for student in data do
    sortBy student.LastName
    thenBy student.FirstName
} |> Seq.iter (printfn "%A")

(* sortByDescending / thenByDescending *)
query {
    for student in data do
    sortByDescending student.LastName
    thenByDescending student.FirstName
} |> Seq.iter (printfn "%A")

(* sumBy *)
query {
    for student in data do
    sumBy student.Age
} |> printfn "%i"

(* averageBy *)
query {
    for student in data do
    averageBy (student.Age |> float)
} |> printfn "%f"

(* minBy *)
query {
    for student in data do
    minBy student.Age
} |> printfn "%i"

(* maxBy *)
query {
    for student in data do
    maxBy student.Age
} |> printfn "%i"

(* groupBy *)
query {
    for student in data do
    groupBy student.Age into g
    select (g.Key, g.Count())
} |> Seq.iter (printfn "%A")

(* groupValBy *)
query {
    for student in data do
    groupValBy $"{student.FirstName} {student.LastName}" student.Age
} |> Seq.iter (printfn "%A")

(* where *)
query {
    for student in data do
    where (student.Age >= 18)
} |> Seq.iter (printfn "%A")

(* find *)
query {
    for student in data do
    find (student.Age >= 18)
} |> printfn "%A"

(* skip *)
query {
    for student in data do
    skip 1
} |> Seq.iter (printfn "%A")

(* skipWhile *)
query {
    for student in data do
    skipWhile student.IsActive
} |> Seq.iter (printfn "%A")

(* take *)
query {
    for student in data do
    take 3
} |> Seq.iter (printfn "%A")

(* takeWhile *)
query {
    for student in data do
    takeWhile student.IsActive
} |> Seq.iter (printfn "%A")

(* join *)
query {
    for student1 in data do
    join student2 in data on (student1.LastName = student2.LastName)
    where (student1.FirstName <> student2.FirstName)
    select (student1, student2)
} |> Seq.iter (printfn "%A")
