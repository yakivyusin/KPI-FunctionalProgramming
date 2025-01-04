type System.Int32 with
    member this.IsEven = this % 2 = 0

let i = 42
printfn "%b" i.IsEven
