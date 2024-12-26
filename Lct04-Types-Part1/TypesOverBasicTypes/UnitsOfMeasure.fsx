[<Measure>] type m
[<Measure>] type sec
[<Measure>] type kg

let distance = 1.0<m>
let time = 2.0<sec>

// Три наступні значення мають одну і ту саму одиницю виміру
let speed = 1.0<m / sec>
[<Measure>] type speed = m / sec
let speed2 = 1.0<speed>
let speed3 = distance / time

let acceleration = speed / time
let mass = 5.0<kg>
let force = mass * speed / time

let wtf = 1<m> + 1<kg>
let wtf2 = 1<m> + 1
let ok = 1<m> * 2

let meterTwoTimes (m: float<m>) = m * 2.0

meterTwoTimes distance |> ignore
meterTwoTimes 2.0
meterTwoTimes 1<kg>

let addKilometer m = m + 1000<m>

addKilometer 1000<m> |> ignore
