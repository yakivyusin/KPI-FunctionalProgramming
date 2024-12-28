let jane1 = "Jane Smith"
                |> (fun x ->
                        let parts = x.Split(' ')
                        {| FirstName = parts.[0]; LastName = parts.[1] |})
                |> (fun x -> {| x with LastName = "Doe" |})

let jane2 = {| FirstName = "Jane"; LastName = "Doe" |}
jane1 = jane2

(*
    З with ми можемо додавати нові члени до інших звичайних/анонімних записів.
    В результаті ми будемо створювати нові анонімні записи.
*)
let janeWithAge = {| jane2 with Age = 30 |}

type GeoCoord = { Lat: float; Long: float }
let kyiv = { Lat = 50.4542; Long = 30.5267 }
let kyivWithAltitude = {| kyiv with Alt = 179.0 |}
