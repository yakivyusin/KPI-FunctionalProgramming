(* Краще дивитися після: лекція 8 *)

(*
    Крім одномірного Array, ми ще маємо двомірні, тримірні та чотиримірні масиви.
*)
let arr1 = Array2D.create 5 5 1
let arr2 = Array3D.create 5 5 5 1
let arr3 = Array4D.create 5 5 5 5 1

arr1.[0, 0] |> printfn "%i"
arr2.[0, 0, 0] |> printfn "%i"
arr3.[0, 0, 0, 0] |> printfn "%i"

arr1 |> Array2D.map (fun x -> x + 10) |> printfn "%A"
arr2 |> Array3D.mapi (fun i j k x -> x + i + j + k) |> Array3D.iter (printfn "%i")
