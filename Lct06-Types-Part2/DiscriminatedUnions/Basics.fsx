(*
    Всі три IntOrBool визначають однаковий тип-суму - відрізняється тільки форматування оголошення
*)

type IntOrBool1 =
    | I of int
    | B of bool

type IntOrBool2 = | I of int | B of bool

type IntOrBool3 = I of int | B of bool

// fail: мітки повинні починатися з великої літери
//type IntOrBool4 = i of int | b of bool

// Why not?
type IntOrBool4 = Int32 of System.Int32 | Boolean of System.Boolean

(*
    До типу-суми можуть входити будь-які типи
*)

type Person = { First: string; Last: string }

type MixedType =
    | Tup of int * int
    | P of Person
    | U of IntOrBool1

// fail: записи / об'єднання повинні бути оголошенні до
//type MixedType2 =
//    | Tup of int * int
//    | P of { First: string; Last: string }
//    | U of (I of int | B of bool)

type Disk =
    | MMC of NumberOfPins: int
    | HardDisk of RPM: int * Platters: int

let disk1 = MMC 5
let disk2 = HardDisk (5400, 7)
let disk3 = MMC (NumberOfPins = 7)
let disk4 = HardDisk (RPM = 7200, Platters = 5)

// Назва випадку є функцією, то чому б і ні?
let disk5 = 5 |> MMC

// fail: let disk6: Disk = null

printfn "%A" disk1
printfn "%A" disk5

match disk1 with
| MMC pins -> printfn "MMC %d" pins
| HardDisk (rpm, platters) -> printfn "HDD %i %i" rpm platters

match disk2 with
| MMC _ -> printfn "MMC"
| HardDisk (5400, _) -> printfn "Slow HDD"
| HardDisk (7200, _) -> printfn "Fast HDD"
| HardDisk _ -> printfn "Some HDD"

// Як і з кортежами чи записами, ми маємо автоматично перевизначене порівняння на рівність
disk1 = disk2
disk1 = disk5

(*
    Так само маємо операції порівняння. Перший випадок завжди буде меншим за другий, другий за третій і так далі.
    Якщо випадки однакові, то порівнюються значення.
*)
disk1 < disk2
disk1 < disk5
