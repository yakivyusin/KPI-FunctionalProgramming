module ``Add Tests``

open FsCheck.Xunit

let add x y = x + y

[<Property(Verbose = true)>]
let commutativeProperty x y =
    let result1 = add x y
    let result2 = add y x
    result1 = result2

(*
    Змінюємо кількість тестів на 10000.
*)
[<Property(MaxTest = 10000)>]
let identityProperty x =
    let result = add x 0
    result = x

(*
    Генератори значень у FsCheck отримують два параметри - кількість значень та параметр size.
    Сенс size визначається типом значення - максимально допустиме значення числа, максимально допустима довжина колекції, тощо.
    Всі властивості запускаються зі значеннями size, що лінійно збільшуються від StartSize (1) до EndSize (100).
*)
[<Property(StartSize = 100, EndSize = 1000)>]
let associativeProperty x y z =
    let result1 = add x (add y z)
    let result2 = add (add x y) z
    result1 = result2
