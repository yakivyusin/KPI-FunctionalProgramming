type Disk =
    | MMC of NumberOfPins: int
    | HardDisk of RPM: int * Platters: int
    | SolidState

type Size = Small | Medium | Large

let disk = SolidState
let shirtSize = Small

match shirtSize with
| Small -> "T-Shirt: Small"
| Medium -> "T-Shirt: Medium"
| Large -> "T-Shirt: Large"
