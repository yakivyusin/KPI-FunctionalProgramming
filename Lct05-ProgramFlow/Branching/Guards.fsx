let elementsAreEqual =
    function
    | (x, y) when x = y -> printfn "both parts are the same"
    | _ -> printfn "both parts are different"

elementsAreEqual ("a", "a")

let makeOrdered =
    function
    | (x, y) when x > y -> (y, x)
    | _ as tuple -> tuple // Крім іменування окремих членів, ми можемо дати ім'я всьому значенню з as


makeOrdered (1, 2)
makeOrdered (2, 1)

let isAM (date: System.DateTime) =
    match date with
    | x when x.Hour <= 12-> printfn "AM"
    | _ -> printfn "PM"

isAM System.DateTime.Now

let classifyString =
    function
    | x when System.Text.RegularExpressions.Regex.Match(x, @".+@.+").Success -> printfn "%s is an email" x
    | x -> printfn "%s is something else" x

classifyString "alice@example.com"
classifyString "google.com"

let fizzBuzz =
    function
    | i when i % 15 = 0 -> printfn "fizzbuzz"
    | i when i % 3 = 0 -> printfn "fizz"
    | i when i % 5 = 0 -> printfn "buzz"
    | i -> printfn "%i" i

fizzBuzz 16
