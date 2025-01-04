(*
    Простір імен може бути оголошений у декількох файлах
*)
namespace Domain

// Domain.Domain
module Domain =

    // Domain.Domain.favoriteCustomer
    let favoriteCustomer =
        { First = "Jane"
          Last = "Smith"
          Address =
            { City = "Kyiv"
              Zip = "03065" } }

    // Domain.Domain.customerFullName
    let customerFullName { First = first; Last = last } = $"{first} {last}"

    // Domain.Domain.Utilities
    module Utilities =

        // Domain.Domain.Utilities.stringifyAddress
        let stringifyAddress { City = city; Zip = zip } = sprintf "%s (%s)" city zip

        // Domain.Domain.Utilities.stringifyCustomer
        let stringifyCustomer { First = first; Last = last; Address = address } =
            stringifyAddress address |> sprintf "%s %s [%s]" first last
