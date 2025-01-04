module Domain.Operations

let create (city, zip) (first, last)  =
    { First = first
      Last = last
      Address =
      { City = city
        Zip = zip }}

let createUnknownCity = create ("Unknown", "Unknown")
