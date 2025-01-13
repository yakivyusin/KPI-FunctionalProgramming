(*
    Нехай у нас є така імперативна логіка:
    ```
    static int NumberFunction(int input)
    {
      if (input < 1)
      {
        return 0;
      }

      input++;

      if (input % 2 != 0)
      {
        return 0;
      }

      return input;
    }
    ```
    Перепишемо її у функційному стилі з використанням Option.
*)

let validation1 num = if num < 1 then None else Some num
let action1 num = num + 1
let validation2 num = if num % 2 <> 0 then None else Some num

let numberFunction num =
    Some num
    |> Option.bind validation1
    |> Option.map action1
    |> Option.bind validation2
    |> Option.defaultValue 0

numberFunction 0 |> printfn "%i"
numberFunction 1 |> printfn "%i"
numberFunction 2 |> printfn "%i"

(*
    Замість bind для перевірки можемо використовувати filter,
    тоді і ці функції будуть "чистими" - без знань про тип-контейнер.
*)
let pureValidation1 num = num >= 1
let pureValidation2 num = num % 2 = 0

let numberFunction2 num =
    Some num
    |> Option.filter pureValidation1
    |> Option.map action1
    |> Option.filter pureValidation2
    |> Option.defaultValue 0

numberFunction2 0 |> printfn "%i"
numberFunction2 1 |> printfn "%i"
numberFunction2 2 |> printfn "%i"

