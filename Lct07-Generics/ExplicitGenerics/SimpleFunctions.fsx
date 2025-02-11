﻿(*
    Ми можемо визначити функцію узагальненою без явного перерахування типів-параметрів.
    Результат подібний до того, що автоматично узагальнить компілятор.
    Але ми хоча б можемо дати змістовні імена типу-параметру.
*)
let printImplicit (x: 'T) (y: 'T) = printfn "%A %A" x y

(*
    Також можемо явно перерахувати типи-параметри після імені функції.
    Пізніше ми тут зможемо додати обмеження типу-параметру, на відміну від першого варіанту.
*)
let printExplicit<'T> (x: 'T) (y: 'T) = printfn "%A %A" x y

// Просто dummy тести показати, що ці функції узагальнені.
printImplicit 1 2
printImplicit 1.0 2.0

printExplicit 1 2
printExplicit 1.0 2.0

(*
    З явним перерахуванням типів-параметрів, ми можемо вказати їх значення під час виклику.
    Це, у тому числі, має вплив на вивід типів.
    Наприклад, тип параметру x у цієї функції автоматично виведеться як int, замість узагальнення.
    Це завдяки явному значенню типу-параметру.
*)
let printOuter x =
    // warning: printImplicit<int> x x
    printExplicit<int> x x

(*
    Просто демонстрація того, що ми можемо не обмежуватися тільки одним типом-параметром.
*)
let toTupleImplicit (x: 'T1) (y: 'T2) = (x, y)
let toTupleExplicit<'T1, 'T2> (x: 'T1) (y: 'T2) = (x, y)

toTupleImplicit 1 1.0 ||> printfn "%A %A"
toTupleExplicit 1 "1" ||> printfn "%A %A"
