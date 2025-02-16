module UnquoteTests

open Xunit
open Swensen.Unquote

[<Fact>]
let ``Department name starts from S`` () =
    let department = {| Name = "Super Team" |}

    department.Name.StartsWith('S') =! true

[<Fact>]
let ``Department name starts from E`` () =
    let department = {| Name = "Empty Team" |}

    test <@ department.Name.StartsWith('E') = true @>
    // try: test <@ department.Name.StartsWith('E') <> true @>

[<Fact>]
let ``Two lists should be same``() =
    test <@ [3; 2; 1; 0] |> List.map ((+) 1) = [1 + 3..-1..1 + 0] @>
    // try: test <@ [3; 2; 1; 0] |> List.map ((+) 1) = [1 + 3..1 + 0] @>
