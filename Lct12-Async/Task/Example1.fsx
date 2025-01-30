(*
    Оскільки у F# функція завжди повертає значення, то неузагальнений Task практично не потрібний (крім взаємодії з C#).
    Ця функція повертає Task<unit>.
*)
let sayHello () = task {
    printfn "Hello, World!"
}

sayHello ()

(*
    Нехай також маємо повністю синхронний код всередині, але хочемо повернути значення.
    Звичний варіант по звичайним функціям видаватиме дивну помилку.
*)
//fail:
//let double x = task {
//    x * 2
//}

(*
    Щоб все запрацювало, нам необхідний старий добрий знайомий з інших мов - return.
    Можемо вважати, що це ключове слово дозволяє "обгорнути" наше значення у тип Task.
*)
let double x = task {
    return x * 2
}

double 10 |> _.Result |> printfn "%i"

(*
    Якщо ми захочемо прив'язати результат виклику асинхронної функції, то ми отримаємо таску у значенні.
    Те саме у C#, якщо ми викликаємо асинхронну функцію без await.
    Замість await у F# ми маємо let! - let-bang.
*)
let quadruple1 x = task {
    let! doubleX = double x
    let! quadrupleX = double doubleX
    return quadrupleX
}

quadruple1 15 |> _.Result |> printfn "%i"

(*
    Конструкції вигляду
        let! something = ...
        return something
    Ми можемо записати дещо простіше за допомогою return! - return-bang.
*)
let quadruple2 x = task {
    let! doubleX = double x
    return! double doubleX
}

quadruple2 20 |> _.Result |> printfn "%i"

(*
    Якщо ж ми хочемо асинхронно виконати операцію, що повертає Task<unit>, то
    використовуємо do! - do-bang.
*)
let sayHelloIdentity name = task {
    do! sayHello ()
    printfn "Hello, %s" name
}

sayHelloIdentity "Peter"

(*
    Ну ви зрозуміли, так само є і use-bang.
*)
open System.Net.Http

let ping () = task {
    use client = new HttpClient ()
    use! response = client.GetAsync "https://google.com"
    printfn "%A" response.StatusCode
}

ping ()
