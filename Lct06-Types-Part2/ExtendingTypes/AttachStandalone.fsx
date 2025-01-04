module Person = 

    type T = { First: string; Last: string }

    let create first last = { First = first; Last = last }

    let fullName { First = first; Last = last } = $"{first} {last}"

    let sortableName { Last = last; First = first } = $"{last} {first}"

    type T with
        static member Create = create
        member this.FullName = fullName this
        member this.SortableName = sortableName this


let john = Person.create "John" "Smith"
let jane = Person.T.Create "Jane" "Doe"

Person.fullName john |> printfn "%s"
printfn "%s" jane.FullName

Person.sortableName john |> printfn "%s"
printfn "%s" jane.SortableName
