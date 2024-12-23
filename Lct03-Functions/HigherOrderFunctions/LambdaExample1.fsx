let greetings isAdult age =
    if isAdult age then printfn "Hello, adult"
    else printfn "Hello, %i-kid" age

greetings (fun age -> age >= 18) 16
greetings (fun age -> age >= 21) 20
