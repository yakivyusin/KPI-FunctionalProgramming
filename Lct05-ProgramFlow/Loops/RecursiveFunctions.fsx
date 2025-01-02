// fail:
//let sumNumbers limit =
//    match limit with
//    | 0 -> 0
//    | x -> x + sumNumbers (x - 1)

let rec sumNumbers limit =
    match limit with
    | 0 -> 0
    | x -> x + sumNumbers (x - 1)

sumNumbers 1 // ok
sumNumbers 10 // ok
sumNumbers 100 // ok
sumNumbers 1000 // а у нас вже stack overflow?
sumNumbers 10000 // а тепер у нас вже точно stack overflow?
sumNumbers 100000 // ну тут вже у нас stack overflow?
sumNumbers 1000000 // а тут у нас stack overflow?

(*
    Компілятор сам оптимізовує хвостову рекурсію у цикли
*)
let tailSumNumbers limit =
    let rec inner current total =
        match current with
        | 0 -> total
        | x -> inner (current - 1) (current + total)
    inner limit 0

tailSumNumbers 1
tailSumNumbers 10
tailSumNumbers 100
tailSumNumbers 1000
tailSumNumbers 10000
tailSumNumbers 100000
tailSumNumbers 1000000

let fibonacci n =
    let rec fibHelper n a b =
        if n = 0 then a
        elif n = 1 then b
        else fibHelper (n - 1) b (a + b)
    fibHelper n 0 1

(*
    +--------------------+---------------------+
    |   ___              |                     |
    |  /   \   NO        |                     |
    |  | o o|            |   Stack overflow    |
    |  \_^_/             |                     |
    |                    |                     |
    +--------------------+---------------------+
    |   ___              |                     |
    |  /   \   YES       |                     |
    |  | ^ ^|            |  Integer overflow   |
    |  \_^_/             |                     |
    |                    |                     |
    +--------------------+---------------------+
*)
fibonacci 100000
