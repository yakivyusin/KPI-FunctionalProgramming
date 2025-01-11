let seq1 = seq { 1; 2; 3 }

let seq2 = seq { 1..3 }
let seq3 = seq { 5..-2..1 }

(*
    Послідовність є лінивою і кожен раз повертає по одному елементу тільки під час її обчислення.
    Тому послідовність може бути навіть безкінечною, але ми можемо її обмежити певною кількістю значень.
*)
let infiniteSeq = seq {
    let mutable n = 0
    while true do
        printfn "Sequence generate: %i" n
        yield n
        n <- n + 1 
}

infiniteSeq |> Seq.takeWhile (fun x -> x < 10) |> Seq.iter (printfn "%i")
