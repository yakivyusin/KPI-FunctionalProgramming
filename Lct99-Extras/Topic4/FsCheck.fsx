(* Краще дивитися після: лекція 15 *)

#r "nuget: FsCheck"

(*
    Для опису пари генератору та шрінкера FsCheck використовує поняття Arbitrary.
    Ми можемо створювати нові Arbitrary на основі існуючих, або на основі повністю власних реалізацій цих двох функцій.
*)

open System
open FsCheck
open FsCheck.Fluent

let countLetters (s: string) = s.ToCharArray () |> Array.filter Char.IsLetter |> _.Length

let ``letters count should equals to string length for only letters strings`` s =
    s |> countLetters = s.Length

(*
    Властивість не пройде, тому що генератор буде генерувати рядки не тільки із літер.
*)
Check.Quick ``letters count should equals to string length for only letters strings``

type LettersOnlyGen =
    (*
        Визначаємо наш Arbitrary на основі існуючого та готової функції-комбінатора Arb.Filter
    *)
    static member Letters () =
        Arb.Filter (ArbMap.Default.ArbFor<string> (), fun s -> s.ToCharArray () |> Array.forall Char.IsLetter)

(*
    Властивість проходить.
*)
Check.One (Config.Quick.WithArbitrary [typeof<LettersOnlyGen>], ``letters count should equals to string length for only letters strings``)
