let age: int = 35

// З точки зору F# конструктор - це така ж функція, тому слово new не потрібне
let url: System.Uri = System.Uri "https://fsharp.org"

// let є іммутабельним, оператор = використовуються для логічного порівняння, а не присвоєння
let comparison: bool = age = 36

// мутабельний let
let mutable mutAge: int = 35
mutAge <- 36

(*
    Використовуємо клас із базової бібліотеки.
    Сам символ є іммутабельним і ми не можемо його перепризначити.
    Але сам об'єкт є мутабельним і можливо мутувати його властивості
*)
let fileInfo: System.IO.FileInfo = System.IO.FileInfo "example.txt"
fileInfo.IsReadOnly <- true
