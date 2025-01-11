(*
    Зіставлення зі зразком для масивів - перевірка на кількість елементів.
*)
let pondArray =
    function
    | [| |] -> printfn "An empty pond"
    | [| fish |] -> printfn "A pond containing one fish: %s" fish
    | [| f1; f2 |] -> printfn "A pond containing two fish: %s and %s" f1 f2
    | _ -> printfn "Too many fish to list!"

pondArray Array.empty
pondArray [| "One fish" |]
pondArray [| "One fish"; "Two fish" |]
pondArray [| "One fish"; "Two fish"; "Three fish" |]

(*
    Зіставлення зі зразокм для списків - перевірка на кількість елементів.
*)
let pondList =
    function
    | [] -> printfn "An empty pond"
    | [ fish ] -> printfn "A pond containing one fish: %s" fish
    | [ f1; f2 ] -> printfn "A pond containing two fish: %s and %s" f1 f2
    | _ -> printfn "Too many fish to list!"

pondList List.empty
pondList [ "One fish" ]
pondList [ "One fish"; "Two fish" ]
pondList [ "One fish"; "Two fish"; "Three fish" ]

(*
    Зіставлення зі зразком для списків - взяття голови та хвоста.
*)
let pondList2 =
    function
    | [] -> printfn "An empty pond"
    | head :: tail -> printfn "A pond containing one fish: %s (and %i more fish)" head (tail |> List.length)

pondList2 List.empty
pondList2 [ "One fish" ]
pondList2 [ "One fish"; "Two fish" ]
pondList2 [ "One fish"; "Two fish"; "Three fish" ]

(*
    Приклади рекурсивних функцій на основі такого зіставлення.
*)
let sum list =
    let rec loop list acc =
        match list with
        | head :: tail -> loop tail (acc + head)
        | [] -> acc
    loop list 0

sum [1; 2; 3]

let min list =
    let rec loop list acc =
        match list with
        | head :: tail -> loop tail (if head < acc then head else acc)
        | [] -> acc
    loop list System.Int32.MaxValue

min [1; 2; 3]
