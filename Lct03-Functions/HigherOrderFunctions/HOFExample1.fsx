let greetings isAdult age =
    if isAdult age then printfn "Hello, adult"
    else printfn "Hello, %i-kid" age

let isUkrainianAdult age = age >= 18
let isUsaAdult age = age >= 21

greetings isUkrainianAdult 16
greetings isUsaAdult 20
