module Tests

open ModuleUnderTest
open Xunit

[<Fact>]
let ``When I add 1 + 2, I expect 3`` () =
    Assert.Equal(3, add 1 2)

[<Fact>]
let ``When I add 2 + 2, I expect 4`` () =
    Assert.Equal(4, add 2 2)

(*
    Можемо перевірити ще декілька випадків через цикл у тілі тесту або за допомогою Theory.
*)
[<Theory>]
[<InlineData(2, 3, 5)>]
[<InlineData(5, 5, 10)>]
[<InlineData(7, 7, 14)>]
[<InlineData(8, 2, 10)>]
[<InlineData(9, 9, 18)>]
[<InlineData(10, 10, 20)>]
let ``When I add two numbers, I expect their sum`` x y sum =
    Assert.Equal(sum, add x y)









































[<Fact>]
let ``When I add two random numbers (100 times), I expect their sum`` () =
    (*
        Повторюємо 100 разів, щоб випадково не потрапити у діапазон 1..10 єдиним запуском.
    *)
    let r = System.Random ()
    for _ = 1 to 100 do
        let x = r.Next 1000
        let y = r.Next 1000
        Assert.Equal(x + y, add x y)

(*
    Як нам протестувати додавання без додавання? Згадати про його _властивості_.
*)

[<Fact>]
let ``When I add two numbers (100 times), the result should not depend on parameter order`` () =
    let r = System.Random ()
    for _ = 1 to 100 do
        let x = r.Next 1000
        let y = r.Next 1000
        Assert.Equal(add x y, add y x)

[<Fact>]
let ``When I add 0 to number (100 times), the result should be equal to this number`` () =
    let r = System.Random ()
    for _ = 1 to 100 do
        let x = r.Next 1000
        Assert.Equal(x, add x 0)

[<Fact>]
let ``When I add three numbers (100 times), the result should not depend on adding order`` () =
    let r = System.Random ()
    for _ = 1 to 100 do
        let x = r.Next 1000
        let y = r.Next 1000
        let z = r.Next 1000
        Assert.Equal(add x (add y z), add (add x y) z)
