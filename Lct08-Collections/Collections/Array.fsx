(*
    У всіх колекціях при ініціалізації зі значеннями використовується ; замість ,
    Адже , використовується для кортежів
*)
let array1 = [| 1; 2; 3 |] // Все ок, масив з трьох чисел
let oopsArray = [| 1, 2, 3 |] // Також все ок, але це масив з одного елемента - кортежа int * int * int

let array2 = [| 1..3 |]
let array3 = [| 5..-2..1 |]

let array4 = [| for i in 1..3 do yield i * i |]
// -> може заміняти do yield, якщо у нас немає додаткової логіки
let array5 = [| for i in 1..3 -> i * i |]

let array6 = [| for i in 1..9 do if i * i < 50 then yield i * i |]

array1.[0] |> printfn "%i"
array1.[0] <- 10
array1.[0] |> printfn "%i"

let array7 = Array.create 10 1
let array8 = Array.zeroCreate<int> 10
let array9 = Array.init 10 (fun i -> i)
             |> Array.map (fun i -> i * i)
             |> Array.filter (fun i -> i < 50)

array9 |> Array.toList
