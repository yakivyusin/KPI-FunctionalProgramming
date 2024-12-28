let parseName (name: string) =
    let parts = name.Split(' ')
    parts.[0], parts.[1]

parseName "Jane Smith"

let divRem a b = (a / b, a % b)

divRem 5 2

(*
    У .NET BCL багато методів, що повертають певне значення + ще мають один чи декілька out параметрів.
    Компілятор F# автоматично відображає такі методи як такі, що повертають кортеж із значення + out параметрів
*)
let isParsed, parsedValue = System.Int32.TryParse("10")

// int * int * int -> int
let returnTupleTotal tuple =
    let x, y, z = tuple
    x + y + z
returnTupleTotal (1, 2, 3)

// int * int * int -> int
let returnTupleTotal2 (x, y, z) = x + y + z
returnTupleTotal2 (1, 2, 3)

(*
    `returnTupleTotal2` як була, так і є функцією лише одного параметру, не трьох.
    Каррування та часткове застосування не працюватимуть з нею.
*)
// fail: let partialTupleTotal = returnTupleTotal2 2 5

// int * int * int -> int -> int
let returnTupleTotal3 (x, y, z) a = x + y + z + a
returnTupleTotal3 (1, 2, 3) 4
// int -> int
let partialReturnTupleTotal3 = returnTupleTotal3 (1, 2, 3)
partialReturnTupleTotal3 4

// int * int -> int * int -> int * int
let addPairs (x, y) (a, b) = (x + a, y + b)
addPairs (1, 2) (3, 4)
// int * int -> int * int
let partialAddPairs = addPairs (1, 2)
partialAddPairs (3, 4)
