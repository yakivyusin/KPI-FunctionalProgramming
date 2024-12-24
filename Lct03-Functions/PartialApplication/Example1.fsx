open System

let buildDate (year:int) month day = DateTime (year, month, day)

let buildDateThisYear = buildDate DateTime.UtcNow.Year
let buildDateThisMonth = buildDateThisYear DateTime.UtcNow.Month

printfn "%A" (buildDate 2024 12 31)
printfn "%A" (buildDateThisYear 12 31)
printfn "%A" (buildDateThisMonth 28)
