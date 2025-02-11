﻿(* Краще дивитися після: лекція 4 *)

(*
    Крім операторів |> та <| у F# визначені ще наступні оператори:
    ||> |||>
    <|| <|||
    Вони приймають кортеж з двох (||) чи з трьох (|||) елементів та функцію,
    деконструюють кортеж та викликають функцію з отриманими параметрами.

    let (||>) (arg1, arg2) func = func arg1 arg2

    let (|||>) (arg1, arg2, arg3) func = func arg1 arg2 arg3

    let (<||) func (arg1, arg2) = func arg1 arg2

    let (<|||) func (arg1, arg2, arg3) = func arg1 arg2 arg3
*)

(1, "1") ||> printfn "%i %s"
(1, 1.0, "1") |||> printfn "%i %f %s"

printfn "%s %i" <|| ("1", 1)
printfn "%f %s %i" <||| (1.0, "1", 1)
