let add x y = x + y
let timesBy x y = x * y
let inc = add 1
let square x = x * x
let double = timesBy 2
let toString x = x.ToString()

let result = 16 |> square |> double |> toString
printfn "%s" result

let answer = 10 |> add 5 |> timesBy 2 |> inc |> add 7 |> timesBy 3
printfn "%i" answer

(*
    Оператори в F# справді є функціями, бінарні - від двох параметрів.
    Просто компілятор дозволяє викликати їх у звичайні формі як "a op b", але можна викликати і як функцію.
*)
let result2 = 16 |> (*) 16 |> (*) 2 |> toString
printfn "%s" result2

let answer2 = 10 |> (+) 5 |> (*) 2 |> (+) 1 |> (+) 7 |> (*) 3
printfn "%i" answer2
