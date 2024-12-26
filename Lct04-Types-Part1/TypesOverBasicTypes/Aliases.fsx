type RealNumber = float
type AdditionFunction = int -> int -> int
type CustomerId = int
type OrderId = int

let x:RealNumber = 3.14
let f:AdditionFunction = fun x y -> x + y

let processCustomerId (id: CustomerId) = 0
let processOrderId (id: OrderId) = 1

(*
    Псевдоніми є лише псевдонімами - весь наступний код чудово компілюється та виконується, не даючи безпеки типів
*)

// Значення правильних псевдонімів
let customerId:CustomerId = 10
let orderId:OrderId = 20

processCustomerId customerId |> ignore
processOrderId orderId |> ignore

// Значення справжніх типів...
processCustomerId 10 |> ignore
processOrderId 20 |> ignore

// Переплутали місцями...
processCustomerId orderId |> ignore
processOrderId customerId |> ignore
