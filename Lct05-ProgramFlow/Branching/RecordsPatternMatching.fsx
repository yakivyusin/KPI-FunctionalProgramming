type Person = { First: string; Last: string }

let person = { First = "John"; Last = "Doe" }

match person with
| { First = "John" } -> printfn "Matched John"
| { Last = "Smith" } -> printfn "Matched some Smith"
| { First = first } -> printfn "Not John, but %s" first
