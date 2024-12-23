let randomByte =
    printfn "Very complex initialization..."
    let r = System.Random()
    let inner () =
        byte (r.Next(0, 256))
    inner

printfn "%A" (randomByte ())
printfn "%A" (randomByte ())
