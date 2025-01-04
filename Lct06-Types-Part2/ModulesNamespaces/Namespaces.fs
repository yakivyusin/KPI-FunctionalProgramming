(*
    Починаємо файл з оголошення простору імен
*)
namespace Domain

// Domain.Address
type Address = { City: string; Zip: string }

// Domain.Customer
type Customer = { First: string; Last: string; Address: Address }

(*
    Кінець простору імен Domain, початок Domain.Sub
*)
namespace Domain.Sub

// Domain.Sub.IntOrBool
type IntOrBool = I of int | B of bool
