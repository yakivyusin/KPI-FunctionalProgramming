(*
    "Лінивий" Async<T>:
*)
let async1 = async {
    printfn "Running Async..."
    return 1
}

(*
    "Жадібний" Task<T>:
*)
let task1 = task {
    printfn "Running Task..."
    return 1
}

async {
    let! first = async1
    let! second = async1
    return first + second
} |> Async.RunSynchronously |> ignore

task {
    let! first = task1
    let! second = task1
    return first + second
} |> (fun x -> x.Wait ())
