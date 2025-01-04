(*
    Інтерпретатор не підтримує простори імен, тому тут оголошення простору імен закоментовано.
    Для проєкту воно має бути розкоментовано.
*)
// namespace Example

// Оголошуємо тип ззовні модуля, але у просторі імен
type PersonType = { First: string; Last: string }

// Оголошуємо модуль для функцій, що працюють з типом
module Person =

    // Кхм, конструктор, кхм
    let create first last = { First = first; Last = last }

    let fullName { First = first; Last = last } = $"{first} {last}"

let person = Person.create "John" "Doe"
Person.fullName person |> printfn "Fullname=%s"

