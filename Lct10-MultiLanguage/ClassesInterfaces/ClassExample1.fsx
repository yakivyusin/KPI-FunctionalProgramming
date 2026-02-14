(*
    Клас із декількома конструкторами, звичайним та статичним методом.
    (name: string, age: int) - конструктор за замовчуванням.
*)
type Student(name: string, age: int) =
    (*
        Тіло конструктора за замовчуванням.
    *)
    do printfn "Student1.name: %s" name
    do printfn "Student1.age: %d" age

    (*
        Додаткові конструктори.
    *)
    new() =
        printfn "%s" "new()"
        Student("Unknown", 0)

    new(name: string) =
        printfn "%s" "new(name)"
        Student(name, 0)

    new(age: int) =
        printfn "%s" "new(age)"
        Student("Unknown", age)

    (*
        Звичайний метод.
        Як і з прикріпленням функцій до типів, замість this ми можемо використовувати будь-яке слово.
        При цьому метод має доступ до значень із конструктору за замовчуванням - name та age.
    *)
    member this.NamePlusAge () = sprintf "%s %i" name age

    (*
        Статичний метод.
    *)
    static member Create name age = Student(name, age)

(*
    Створення екземплярів / виклики функцій нічим не відрізняються від класів із C#.
*)
let john = Student ("John Smith", 18)
let jane = Student ("Jane Doe")
let max = Student.Create "Max Mueller" 20

[john; jane; max] |> List.iter (fun x -> printfn "%s" <| x.NamePlusAge ())
