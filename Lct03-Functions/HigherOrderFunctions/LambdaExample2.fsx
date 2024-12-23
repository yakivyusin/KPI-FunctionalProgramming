﻿let counter start =
    let mutable current = start
    fun () ->
        let this = current
        current <- current + 1
        this

let counter1 = counter 10
let counter2 = counter 100

printfn "%i %i" (counter1 ()) (counter2 ())
printfn "%i %i" (counter1 ()) (counter2 ())
