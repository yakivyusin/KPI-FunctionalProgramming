for i = 1 to 10 do
    printf "%i " i

printfn ""

for i = 10 downto 1 do
    printf "%i " i

// warning
// for i = 1 to 10 do
//    i * i

for i = 1 to 10 do
    i * i |> ignore

let sumNumbers limit =
    let mutable sum = 0
    for i = 1 to limit do
        sum <- sum + i
    sum

sumNumbers 10

(*
    for...in буде працювати зі всім, що реалізовує інтерфейс System.Collections.IEnumerable.
    Це стосується як і нативних F# колекцій, так і колекцій з .NET BCL.
    Щоб не спойлерити нативні колекції, будемо працювати з List<T> із BCL :)
*)
open System.Collections.Generic

let list = List()
list.Add("Hello")
list.Add("World")

for item in list do
    printfn "%s" item

let tuplesList = List()
tuplesList.Add((1, 2))
tuplesList.Add((3, 4))

for (first, second) in tuplesList do
    printfn "%i %i" first second

let sumNumbers1 limit =
    let mutable sum = 0
    for i in 1 .. limit do
        sum <- sum + i
    sum

sumNumbers1 10

let sumNumbers2 limit =
    let mutable current = limit
    let mutable sum = 0
    while not (current = 0) do
        sum <- sum + current
        current <- current - 1
    sum

sumNumbers2 10
