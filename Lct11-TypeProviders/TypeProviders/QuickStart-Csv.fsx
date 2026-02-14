(*
    За замовчуванням F# Interactive запускається з робочою директорією %Temp%.
    Тому змінюємо поточну директорію, щоб знаходилися файли.
*)
System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

#r "nuget: FSharp.Data"

open FSharp.Data

type Employee = CsvProvider<"sample_data.csv">

let data = Employee.GetSample().Rows |> Array.ofSeq

data |> printfn "%A"

data |> Array.map (fun x -> x.Salary) |> Array.max |> printfn "Max salary: %f"

let youngestEmployee = data |> Array.minBy (fun x -> x.Age)
(youngestEmployee.Name, youngestEmployee.Age) ||> printfn "Youngest employee is %s, %i old"

(*
    Які ж ми дата сатаністи, якщо не зробимо хоча б одну діаграмку?
*)
#r "nuget: XPlot.Plotly"

open XPlot.Plotly

data
|> Array.map (fun x -> (x.Age, x.Salary))
|> Chart.Scatter
|> Chart.WithLayout (Layout(title = "Age / Salary"))
|> Chart.Show
