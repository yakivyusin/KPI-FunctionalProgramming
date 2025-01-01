let v = if true then "a" else "b"

let f x = if x then "a" else "b"
printfn "%s" <| f false

// if вираз, то чому б і не повернути функцію?
let greetings =
    if (System.DateTime.Now.Hour < 12)
    then (fun name -> "Good morning, " + name)
    else (fun name -> "Good day, " + name)

printfn "%s" <| greetings "Peter"

// if гарно виглядає в однорядкових лямбдах
15 |> fun x -> if x % 15 = 0 then printfn "FizzBuzz"
