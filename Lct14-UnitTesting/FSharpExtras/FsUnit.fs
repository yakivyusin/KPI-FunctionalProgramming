module FsUnitTests

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``FsUnit basic asserts`` () =
    1 |> should equal 1
    1 |> should not' (equal 2)

    (*
        Для чисел доступне вказання точності порівняння
    *)
    10.1 |> should (equalWithin 0.1) 10.11
    10.1 |> should not' ((equalWithin 0.001) 10.11)

    2.0 |> should not' (be NaN)

    true |> should be True
    false |> should not' (be True)

    let anObj = obj()
    let otherObj = obj()
    anObj |> should not' (be Null)
    anObj |> should not' (be null)
    anObj |> should be (sameAs anObj)
    anObj |> should not' (be sameAs otherObj)

[<Fact>]
let ``FsUnit strings asserts`` () =
    "ships" |> should startWith "sh"
    "ships" |> should not' (startWith "ss")
    "ships" |> should endWith "ps"
    "ships" |> should not' (endWith "ss")
    "ships" |> should haveSubstring "hip"
    "ships" |> should not' (haveSubstring "pip")

    "" |> should be EmptyString
    "" |> should be NullOrEmptyString

[<Fact>]
let ``FsUnit collections asserts`` () =
    seq { 1; 2; 3 } |> should equalSeq (seq { 1; 2; 3 })
    seq { 1 } |> should not' (equalSeq (seq { 1; 2 }))

    (*
        Ігнорує порядок, але недоступно для xUnit
    *)
    //[2; 4; 6] |> should equivalent [4; 6; 2]
    //[2; 4; 6] |> should not' (equivalent [4; 8; 2])

    [1] |> should contain 1
    [] |> should not' (contain 1)

    [1..4] |> should haveLength 4
    ResizeArray() |> should not' (haveCount 4)

    [] |> should be Empty
    [1] |> should not' (be Empty)

    [1; 2; 3] |> should be unique

    [1; 2; 3] |> should be ascending
    [1; 3; 2] |> should not' (be ascending)
    [3; 2; 1] |> should be descending
    [3; 1; 2] |> should not' (be descending)

    [1..10] |> should be (supersetOf [3; 6; 9])
    [1..10] |> should not' (be supersetOf [5; 11; 21])

    [3; 6; 9] |> should be (subsetOf [1..10])
    [5; 11; 21] |> should not' (be subsetOf [1..10])

[<Fact>]
let ``FsUnit fails/throw asserts`` () =
    (fun () -> failwith "BOOM!" |> ignore) |> should throw typeof<System.Exception>
    (fun () -> failwith "BOOM!" |> ignore) |> should (throwWithMessage "BOOM!") typeof<System.Exception>
    (fun () -> 5/0 |> ignore) |> shouldFail

[<Fact>]
let ``FsUnit comparison asserts`` () =
    11 |> should be (greaterThan 10)
    9 |> should not' (be greaterThan 10)
    11 |> should be (greaterThanOrEqualTo 10)
    9 |> should not' (be greaterThanOrEqualTo 10)
    10 |> should be (lessThan 11)
    10 |> should not' (be lessThan 9)
    10.0 |> should be (lessThanOrEqualTo 10.1)
    10 |> should not' (be lessThanOrEqualTo 9)

[<Fact>]
let ``FsUnit types asserts`` () =
    0.0 |> should be ofExactType<float>
    1 |> should not' (be ofExactType<obj>)

    "test" |> should be instanceOfType<string>
    "test" |> should not' (be instanceOfType<int>)
