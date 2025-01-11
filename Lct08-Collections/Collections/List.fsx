let list1 = [ 1; 2; 3 ]

let list2 = [ 1..3 ]
let list3 = [ 5..-2..1 ]

let list4 = [ for i in 1..3 do yield i * i ]
let list5 = [ for i in 1..3 -> i * i ]

let list6 = [ for i in 1..9 do if i * i < 50 then yield i * i ]

let list7 = list1 @ list2
let list8 = 6 :: list3

list7 |> List.distinct |> List.partition (fun x -> x < 2)
