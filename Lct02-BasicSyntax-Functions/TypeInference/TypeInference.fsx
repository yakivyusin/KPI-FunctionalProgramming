// Щоб не отримувати помилки при перегляді у Visual Studio, створимо вкладені області видимості для використання shadowing
let scope1 =

    // int -> int -> int
    let add (a: int) (b: int) : int = a + b

    // int -> int -> int
    let add (a: int) (b: int) = a + b

    // int -> int -> int
    let add (a: int) b = a + b

    // int -> int -> int
    let add a b = a + b

    // string -> string -> string
    let concatenate a b = "Hello " + a + b

    // float -> float -> float
    let add a b = a + b
    ignore (add 1.0 2.0)

    // int -> int -> int
    let add a b = a + b
    ignore (add 1 2)
    // ignore (add 1.0 2.0)
    // ignore (add "1" "2")

    // string -> string -> string
    let add a b = a + b
    ignore (add "1" "2")
    // ignore (add 1.0 2.0)
    // ignore (add 1 2)

    let inline add a b = a + b
    ignore (add 1 2)
    ignore (add 1.0 2.0)
    ignore (add "1" "b")

    0

let scope2 =
    // let getLength str = str.Length
    // getLength "a"

    // let getLength (str: string) = str.Length
    // let hello str = sprintf "Hello %d times" (getLength str)

    0

let scope3 =
    let list = System.Collections.Generic.List<_>()
    list.Add 10
    list.Add 20

    let list = System.Collections.Generic.List()
    list.Add "a"
    list.Add "b"

    list

let sayHello(someValue) =
    let innerFunction(number) =
        if number > 10 then "Isaac"
        elif number > 20 then "Fred"
        else "Sara"

    let resultOfInner =
        if someValue < 10.0 then innerFunction(5)
        else innerFunction(15)

    "Hello " + resultOfInner

let result = sayHello(10.5)
