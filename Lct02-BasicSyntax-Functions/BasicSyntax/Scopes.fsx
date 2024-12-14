open System

let age: int =
    let currentYear: int = DateTime.Now.Year
    currentYear - 1994

let estimatedAge: string =
    let age: int =
        let year: int = DateTime.Now.Year
        year - 1994
    sprintf "You are about %d years old!" age

let estimateAges (familyName: string) (year1: int) (year2: int) (year3: int) : string =
    let calculateAge (yearOfBirth: int) : int =
        let year = System.DateTime.Now.Year
        year - yearOfBirth

    let estimatedAge1: int = calculateAge year1
    let estimatedAge2: int = calculateAge year2
    let estimatedAge3: int = calculateAge year3
    let averageAge: int = (estimatedAge1 + estimatedAge2 + estimatedAge3) / 3

    sprintf "Average age for family %s is %d" familyName averageAge

// F# дозволяє shadowing символів у будь-якій області видимості, крім області видимості модуля
let shadowing: string =
    let res: int = 10
    let res: string = "10"
    res
