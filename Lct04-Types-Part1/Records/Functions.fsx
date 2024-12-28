type ComplexNumber = { Real: float; Imaginary: float }

let getRealPart complexNumber = complexNumber.Real
let mathPrint complexNumber =
    let { Real = real; Imaginary = imaginary } = complexNumber
    printfn "%f%+fi" real imaginary

let getImaginaryPart { Imaginary = imaginary } = imaginary
let mathPrint2 { Real = real; Imaginary = imaginary } = printfn "%f%+fi" real imaginary

let value = { Real = 1; Imaginary = 2 }
getRealPart value
getImaginaryPart value
mathPrint value
mathPrint2 value

type FullName = { FirstName: string; LastName: string }

let parseName (name: string) =
    let parts = name.Split(' ')
    { FirstName = parts.[0]; LastName = parts.[1] }

parseName "Jane Smith"
