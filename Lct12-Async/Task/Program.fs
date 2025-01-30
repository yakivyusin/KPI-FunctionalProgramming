(*
    async main - фіча компілятора C#, який просто створює прихований метод під капотом.
    У F# такого немає, тому потрібно самому викликати .Result або .GetAwaiter().GetResult().
*)

open System.Net.Http
open System.Threading.Tasks

[<EntryPoint>]
let main args =
    use client = new HttpClient ()

    let printStatus (x: string) = task {
        use! response = client.GetAsync x
        printfn "%s: %A" x response.StatusCode
    }

    args |> Array.map printStatus |> Task.WhenAll |> _.Result |> ignore
    0
