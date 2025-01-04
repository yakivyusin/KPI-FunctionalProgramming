type DiskUnion =
    | MMC
    | HardDisk
    | SolidState

type DiskEnum =
    | MMC = 0
    | HardDisk = 1
    | SolidState = 2

let unionDisk = MMC
let enumDisk = DiskEnum.MMC

// OK:
let matchUnion =
    function
    | MMC -> ()
    | HardDisk -> ()
    | SolidState -> ()

matchUnion unionDisk

// Ніколи не буде вичерпним
let matchEnum =
    function
    | DiskEnum.MMC -> ()
    | DiskEnum.HardDisk -> ()
    | DiskEnum.SolidState -> ()

matchEnum enumDisk

// І ось чому:
let wrongEnum = enum<DiskEnum> 10
matchEnum wrongEnum
