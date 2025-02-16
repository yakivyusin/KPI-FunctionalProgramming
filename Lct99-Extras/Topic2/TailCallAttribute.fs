(* Краще дивитися після: лекція 5 *)

(*
    Для контролю того, чи оптимізовується наша рекурсивна функція як хвостова рекурсія, доступний атрибут [<TailCall>].
    Якщо функція не оптимізовується, то компілятор видасть попередження виду
    warning FS3569: The member or function '...' has the 'TailCallAttribute' attribute, but is not being used in a tail recursive way.

    На жаль, це не працює із F# Interactive, тільки повноцінною компіляцією, і підсвітки у Visual Studio немає.
*)

module TailCallAttributeSample

[<TailCall>]
let rec sumNumbers limit =
    match limit with
    | 0 -> 0
    | x -> x + sumNumbers (x - 1)

[<TailCall>]
let rec tailSumNumbers limit total =
    match limit with
    | 0 -> total
    | x -> tailSumNumbers (limit - 1) (limit + total)
