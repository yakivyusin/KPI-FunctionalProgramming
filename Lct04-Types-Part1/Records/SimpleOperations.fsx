type ComplexNumber =
    { Real: float
      Imaginary: float }

type GeoCoord = { Lat: float; Long: float }

type GeoBox = { LeftTopCorner: GeoCoord; RightBottomCorner: GeoCoord }

type BasicArithmeticOperations = { Addition: int -> int -> int; Multiplication: int -> int -> int }

let complexNumber =
    { Real = 2.0
      Imaginary = 3.0 }

let kyiv = { Lat = 50.4542; Long = 30.5267 }

let box = { LeftTopCorner = { Lat = 51.348; Long = 25.849 }; RightBottomCorner = kyiv }

let operations = { Addition = (fun x y -> x + y); Multiplication = (fun x y -> x * y) }

// fail: let somewhere = { Lat = 0.0 }
// fail: let absent: ComplexNumber = null

let kyiv2 = { Long = 30.5267; Lat = 50.4542 }

(*
    Як і з кортежами, операція порівняння автоматично перевизначена.
    Перевіряються всі члени між собою.
*)
kyiv = kyiv2

(*
    Якщо всі члени запису підтримують порівняння, то ми автоматично можемо порівнювати записи, як і кортежі.
    Відбувається порівняння у порядку визначення членів у оголошенні запису.
*)
complexNumber < { Real = 3.0; Imaginary = 0.0 }
complexNumber < { Real = 2.0; Imaginary = 1.0 }

(*
    Компілятор не зможе автоматично вивести тип, якщо ми матимемо декілька записів з однаковими членами.
    Замість анотації типу на символі, ми можемо вказати ім'я типу при доступі до члена - достатньо для одного.
*)
let zeroPoint = { GeoCoord.Lat = 0.0; Long = 0.0 }

printfn "Kyiv lat: %A, long: %A" kyiv.Lat kyiv.Long

let { Lat = kyivLat; Long = kyivLong } = kyiv
let { Lat = kyivLat2; Long = _ } = kyiv
let { Lat = kyivLat3 } = kyiv // З кортежем так не вийде

// fail: kyiv.Lat <- 50.45
let kyivNewExplicit = { Lat = 50.45; Long = kyiv.Long }
let kyivNewWithWith = { kyiv with Lat = 50.45 }
