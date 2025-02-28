let add x y = x + y

let genericLogger before after anyFunc input =
    before input
    let result = anyFunc input
    after result
    result 

genericLogger (printfn "Before: %i") (printfn "After: %i") (add 1) 2
