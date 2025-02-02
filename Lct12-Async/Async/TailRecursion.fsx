(*
    Спробуємо написати рекурсивну асинхронну функцію, використовуючи task:
*)
let rec sumTailRecAsync n acc = task {
    if n <= 0 then 
        return acc
    else 
        return! sumTailRecAsync (n - 1) (acc + n)
}

(*
    Пробуємо...
*)
sumTailRecAsync 100 0 |> _.Result |> printfn "Sum: %d" // OK
sumTailRecAsync 1000000 0 |> _.Result |> printfn "Sum: %d" // Oops...

(*
    Переписуємо на async - замінюємо один вираз іншим і перейменовуємо функцію...
*)
let rec asyncSumTailRec n acc = async {
    if n <= 0 then 
        return acc
    else 
        return! asyncSumTailRec (n - 1) (acc + n)
}

(*
    Пробуємо...
*)
asyncSumTailRec 1000000 0 |> Async.RunSynchronously |> printfn "Sum: %d" // OK!
