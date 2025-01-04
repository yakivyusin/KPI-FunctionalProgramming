(*
    Інтерпретатор не підтримує простори імен, тому тут оголошення простору імен закоментовано.
    Для проєкту воно має бути розкоментовано.
    Або можемо оголосити модулем верхнього рівня.
*)
// namespace Example

module Person =

    // Person.T - головний тип для цього модуля
    type T = { First: string; Last: string }

    // Кхм, конструктор, кхм
    let create first last = { First = first; Last = last }

    let fullName { First = first; Last = last } = $"{first} {last}"

let person = Person.create "John" "Doe"
Person.fullName person |> printfn "Fullname=%s"
