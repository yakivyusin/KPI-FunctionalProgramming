module Module1 =
    type Person = { First: string; Last: string; }

module Module2 =
    type Module1.Person with
        member this.SortableName = $"{this.Last} {this.First}"

open Module1

let jane = { First = "Jane"; Last = "Smith" }

// fail: Ми не відкрили модуль Module2, тому компілятор не бачить прикріплену функцію
// printfn "%s" jane.SortableName

open Module2

printfn "%s" jane.SortableName
