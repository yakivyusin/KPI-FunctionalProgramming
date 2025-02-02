(* Краще дивитися після: лекція 2 *)

(*
    Крім let-прив'язки, у F# існують ще дві інші: do та use.
*)

(*
    do використовується для виклику виразів, що повертають unit, без визначення символу.
    По правильному, ми повинні завжди використовувати do у таких випадках, але
    компілятор дозволяє у більшості випадків обійтися без нього.
    Але є ситуації, коли do обов'язковий.
*)
printfn "Hello, World!"
do printfn "Hello, World!"

(*
    Прив'язка use використовується для значень, що реалізовують інтерфейс IDisposable.
    Тоді метод Dispose() буде викликано автоматично при завершенні поточної області видимості.
*)
let readFile file =
    use stream = System.IO.File.Open (file, System.IO.FileMode.Open)
    use reader = new System.IO.StreamReader (stream)
    reader.ReadToEnd ()

System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let self = readFile "DoUse.fsx"
printfn "%s" self
