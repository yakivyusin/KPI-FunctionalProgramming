module FsUnitTypedTests

open Xunit
open FsUnit.Xunit
open FsUnitTyped

[<Fact>]
let ``FsUnitTyped asserts overview`` () =
    (*
        ;-(
    *)
    //1 |> should equal "1"

    1 |> shouldEqual 1
    1 |> shouldNotEqual 2

    11 |> shouldBeGreaterThan 10
    10 |> shouldBeSmallerThan 11

    "ships" |> shouldContainText "hip"

    [1] |> shouldContain 1
    [] |> shouldNotContain 1
    [] |> shouldBeEmpty

    [|1..4|] |> shouldHaveLength 4

    (fun _ -> failwith "BOOM!") |> shouldFail<System.Exception>
    (fun _ -> 5/0 |> ignore) |> shouldFail 
