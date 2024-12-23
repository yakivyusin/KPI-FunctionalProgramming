let randomByte =
    printfn "Very complex initialization..."
    let r = System.Random()
    fun () -> byte (r.Next(0, 256))

printfn "%A" (randomByte ())
printfn "%A" (randomByte ())

