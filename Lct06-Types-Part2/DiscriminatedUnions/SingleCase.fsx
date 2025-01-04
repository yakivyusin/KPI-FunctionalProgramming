type CustomerId = CustomerId of int

let customerId = CustomerId 10

let find (CustomerId customerId) = printfn "%i" customerId

find customerId

// fail: find 10

let (CustomerId orig) = customerId
